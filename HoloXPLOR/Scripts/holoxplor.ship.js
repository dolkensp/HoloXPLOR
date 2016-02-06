var pause = {};

$(document).ready(function () {
    var debug = false;
    var $form = $('#form-ship');

    if ($form.length == 0) return;

    var fadeTimer = null;
    var $source = null;

    var inventoryMap = {};

    $.ajax({ url: '/HoloTable/Inventory', dataType: 'json', success: function (data) { inventoryMap = data } })
    
    var cleanType = function(type)
    {
        type = type.replace('WeaponGun:Gun', 'Gun');
        type = type.replace('WeaponGun:NoseMounted', 'Nose Mounted Gun');
        type = type.replace('WeaponGun', 'Gun');
        type = type.replace('Turret:GunTurret', 'Gimbal');
        type = type.replace('Turret:Gun', 'Gimbal');
        type = type.replace('Turret:BallTurret', 'Ball Turret');
        type = type.replace('Turret', 'Turret/Gimbal');
        type = type.replace('GimbalTurret', 'Gimbal');
        type = type.replace('GunTurret', 'Gimbal');
        type = type.replace('Container:Cargo', 'Cargo Container');
        type = type.replace('Turret:CanardTurret', 'Canard Turret');
        type = type.replace('WeaponMissile:MissileRack', 'Missile Rack');
        type = type.replace('WeaponMissile', 'Missile Rack');
        type = type.replace('MainThruster', 'Engine');
        type = type.replace('ManneuverThruster:JointThruster', 'Thruster');
        type = type.replace('ManneuverThruster', 'Thruster');
        type = type.replace('PowerPlant', 'Power Plant');
        type = type.replace('Paints', 'Paint');
        type = type.replace('Ordinance:', '');
        type = type.replace('AmmoBox:', '');
        type = type.replace('Ammo_:', '');
        type = type.replace('CounterMeasure:', 'Counter Measure');
        type = type.replace('_', ' ');
        type = type.replace(':', ' ');

        return type;
    }

    var getInfo = function($target)
    {
        var $markup = $('<div>');

        if ($target.data('empty') != undefined)
        {
            $markup = $('<h4 class="alert-danger">Remove Item</h4>');
            return $markup;
        }

        if ($target.hasClass('js-available')) {
            $markup.append('<h4>Available</h4>');
        } else {
            $markup.append('<h4>Equipped</h4>');
        }
        $markup.append('<p><strong>Name:</strong> ' + $target.attr('title') + '</p>');
        if ($target.data('item-size') != undefined) {
            if ($target.data('port-max-size') != undefined) {
                $markup.append('<p><strong>Size:</strong> ' + $target.data('item-size') + ' (' + $target.data('port-max-size') + ')</p>');
            } else {
                $markup.append('<p><strong>Size:</strong> ' + $target.data('item-size') + '</p>');
            }
        } else if ($target.data('port-max-size') != undefined) {
            $markup.append('<p><strong>Size:</strong> Empty (' + $target.data('port-max-size') + ')</p>');
        }
        if ($target.data('parent-name') != undefined && $target.data('port-name') != undefined) {
            $markup.append('<p><strong>Mount:</strong> ' + $target.data('parent-name') + ' - ' + $target.data('port-name') + '</p>');
        }
        if ($target.data('parent-name') == undefined && $target.data('port-name') != undefined) {
            $markup.append('<p><strong>Mount:</strong> ' + $target.data('port-name') + '</p>');
        }

        // if ($target.data('item-type') != undefined) {
        //     $markup.append('<p><strong>Type:</strong> ' + cleanType($target.data('item-type') + ':' + $target.data('item-sub-type') || '') + '</p>');
        // }

        if ($target.data('port-types') != undefined) {
            var accepted = [];

            $.each($target.data('port-types').split(','), function () {
                var type = this;

                type = cleanType(type);

                accepted.push(type);
            });

            $markup.append('<p><strong>Accepted:</strong> ' + $.unique(accepted).join(', ') + '</p>');
        }

        if ($target.data('item-name') != undefined) {
            var itemData = inventoryMap[$target.data('item-name')];

            if (itemData != undefined)
            {
                if (itemData.Armor != undefined) {
                    $markup.append('<p><strong>Physical Res:</strong> ' + Math.round(100 - itemData.Armor.DamageMultipliers[0].Physical * 100) + '%</p>');
                    $markup.append('<p><strong>Energy Res:</strong> ' + Math.round(100 - itemData.Armor.DamageMultipliers[0].Energy * 100) + '%</p>');
                    $markup.append('<p><strong>Distortion Res:</strong> ' + Math.round(100 - itemData.Armor.DamageMultipliers[0].Distortion * 100) + '%</p>');
                }

                if (itemData.Shields != undefined) {
                    $markup.append('<h5>Shield</h5>');

                    $markup.append('<p><strong>Type:</strong> ' + itemData.Shields.FaceType + '</p>');
                    $markup.append('<p><strong>HP:</strong> ' + itemData.Shields.MaxHitPoints + '</p>');
                    $markup.append('<p><strong>Regen Rate:</strong> ' + itemData.Shields.MaxRegenRate + '</p>');
                    $markup.append('<p><strong>Regen Delay:</strong> ' + itemData.Shields.RegenDelay + '</p>');

                    $markup.append('<h5>Physical</h5>');
                    $markup.append('<p><strong>Damage Absorb:</strong> ' + itemData.Shields.Physical_DamageAbsorbDirect + '</p>');
                    $markup.append('<p><strong>Splash Absorb:</strong> ' + itemData.Shields.Physical_DamageAbsorbSplash + '</p>');

                    $markup.append('<h5>Energy</h5>');
                    $markup.append('<p><strong>Damage Absorb:</strong> ' + itemData.Shields.Energy_DamageAbsorbDirect + '</p>');
                    $markup.append('<p><strong>Splash Absorb:</strong> ' + itemData.Shields.Energy_DamageAbsorbSplash + '</p>');

                    $markup.append('<h5>Distortion</h5>');
                    $markup.append('<p><strong>Damage Absorb:</strong> ' + itemData.Shields.Distortion_DamageAbsorbDirect + '</p>');
                    $markup.append('<p><strong>Splash Absorb:</strong> ' + itemData.Shields.Distortion_DamageAbsorbSplash + '</p>');
                }

                console.log(itemData);
            }
        }

        return $markup;
    }

    var getComparison = function ($equipped, $available) {
        var $markup = $('<div>');

        $markup.append(getInfo($equipped));

        if ($equipped != $available) {
            $markup.append(getInfo($available));
        }

        return $markup;
    }

    var hideInfo = function (timeout) {
        window.clearTimeout(fadeTimer);
        fadeTimer = window.setTimeout(function () {
            var $markup = $('<div class="panel-body js-info">');

            if ($source != null) {
                $markup.append(getInfo($source));
            } else {
                $markup.html('Hover over an item to see more information');
            }

            $('.js-info').replaceWith($markup);
        }, timeout);
    };

    var showInfo = function ($target) {
        window.clearTimeout(fadeTimer);
        var $markup = $('<div class="panel-body js-info">');
        var $equipped = $target;
        var $available = $source;

        if ($target.hasClass('js-available'))
        {
            $equipped = $source;
            $available = $target;
        }

        if ($equipped != null && $available != null)
        {
            $markup.append(getComparison($available, $equipped));
        } else if ($equipped != null) {
            $markup.append(getInfo($equipped));
        } else if ($available != null) {
            $markup.append(getInfo($available));
        }

        $('.js-info').replaceWith($markup);
    }

    var acceptItem = function ($item) {
        var $port = $(this);

        if ($port.data('empty') != undefined)
            return true;

        // ensure we're always checking the item vs the port
        if (!$item.hasClass('js-available') && $port.hasClass('js-available')) {
            var temp = $item;
            $item = $port;
            $port = temp;
        }

        if (!$item.hasClass('js-available') && !$port.hasClass('js-available')) {
            return false;
        }

        // TODO: Allow removal of items

        if (!debug) { /* Check item sizes */
            var itemSize = parseInt($item.data('item-size'));
            var minSize = parseInt($port.data('port-min-size'));
            var maxSize = parseInt($port.data('port-max-size'));

            if (itemSize < minSize || itemSize > maxSize) {
                // console.log("Rejected Size", minSize, itemSize, maxSize);
                return false;
            }
        }

        if (!debug) { /* Normally, ship-specific tags */
            var requiredPortTags = ($item.data('item-required-port-tags') || '').toLowerCase().split(' ');
            var portTags = ($port.data('port-tags') || '').toLowerCase().split(' ');
            var shipPortTags = ($port.data('ship-port-tags') || '').toLowerCase().split(' ');

            if ($(requiredPortTags).not(portTags).not(shipPortTags).not(['']).length > 0) {
                // console.log("Rejected Port Tags", requiredPortTags, portTags, shipPortTags);
                return false;
            }
        }

        if (!debug) { /* Normally, equipment-specific tags */
            var requiredItemTags = ($port.data('port-required-tags') || '').toLowerCase().split(' ');
            var portItemTags = ($port.data('port-required-item-tags') || '').toLowerCase().split(' ');
            var itemTags = ($item.data('item-tags') || '').toLowerCase().split(' ');

            if ($(requiredItemTags).not(itemTags).not(['']).length > 0 || $(portItemTags).not(itemTags).not(['']).length > 0) {
                // console.log("Rejected Item Tags", requiredItemTags, itemTags);
                return false;
            }
        }

        { /* Item types */
            var type = ($item.data('item-type') || '').toLowerCase();
            var subType = ($item.data('item-sub-type') || '').toLowerCase();
            var fullType = (subType == "") ? type : (type + ":" + subType);

            var accepted = ($port.data('port-types') || '').toLowerCase().split(',');

            for (var i = 0, j = accepted.length; i < j; i++) {
                if (accepted[i] == type || accepted[i] == fullType || accepted[i] == subType)
                    return true;
            }

            // console.log("Rejected Type", type, subType, accepted);
        }

        return false;
    }

    var bindAll = function (parent) {

        $("[data-draggable]:not(.js-equipped):not(.js-draggable)").addClass('js-draggable').draggable({
            helper: "clone",
            appendTo: "body",
            cursorAt: { left: 16, top: 16 },
            start: function () { $source = $(this); showInfo($source); if ($(this).data('equipped') != undefined) $('.js-empty').show(); },
            stop: function () { $source = null; hideInfo(250); $('.js-empty').hide(); }
        });

        $("[data-droppable]:not(.js-droppable)").addClass('js-droppable').droppable({
            accept: acceptItem,
            activeClass: "ui-state-default",
            hoverClass: "ui-state-hover",
            drop: dropItem,
            over: function() { showInfo($(this)) },
            out: function () { hideInfo(250) }
        });

        $("li.js-hardpoint:not(.js-tooltip)").addClass('js-tooltip').on('mouseover', function () {
            if ($source == null) showInfo($(this))
        }).on('mouseout', function () {
            if ($source == null) hideInfo(500)
        });

        var $panecontainer = $('#primary-pane');
        var isscrolling = false;
        var $currscrollbar = $('#primary-pane-scrollbar');
        var scrollbarpos;
        var $currcontent;
        var $infocontent;

        // Scrolling
        $currscrollbar.on('mousedown', function (e) {
            isscrolling = true;
            $currcontent = $('.active .js-scrollable');
            scrollbarpos = e.pageY - $currscrollbar.offset().top;
            $('body').addClass('shipcatalogue_scrollingcursor');
            $currscrollbar.find('span').addClass('shipcatalogue_descscrollbarglow');
            return false;
        });
        $(document).bind('mouseup', function () {
            if (isscrolling) {
                isscrolling = false;
                $('body').removeClass('shipcatalogue_scrollingcursor');
                $currscrollbar.find('span').removeClass('shipcatalogue_descscrollbarglow');
            }
        });
        $(document).bind('mousemove', function (e) {
            if (isscrolling) {
                var newpos = $currscrollbar.position().top - (scrollbarpos - (e.pageY - $currscrollbar.offset().top));
                var parentH = $panecontainer.height();
                if (newpos < 15) {
                    newpos = 15;
                } else if (newpos > 390) {
                    newpos = 390;
                }
                $currscrollbar.css('top', newpos);
                if ($currcontent.height() > parentH) {
                    $currcontent.css('top', Math.round((((newpos - 15) / 411) * ($currcontent.height() - parentH)) * -1));
                }
            }
        });
        $panecontainer.on('mousewheel', function (e) {
            if (!isscrolling) {
                $currcontent = $('.active .js-scrollable');
                if ($currcontent.length == 0) return;

                var parentH = $panecontainer.height();
                var offset = (e.originalEvent.wheelDelta / 120 > 0 ? -50 : 50);
                var newpos = $currscrollbar.position().top + (e.originalEvent.wheelDelta / 120 > 0 ? -50 : 50);
                if (newpos < 15) {
                    newpos = 15;
                } else if (newpos > 390) {
                    newpos = 390;
                }
                $currscrollbar.css('top', newpos);
                if ($currcontent.height() > parentH) {
                    $currcontent.css('top', Math.round((((newpos - 15) / 411) * ($currcontent.height() - parentH)) * -1));
                }
            }
        });
    }

    var dropItem = function (event, ui) {

        var $item = $(this);
        var $port = $(ui.draggable);

        // ensure we're always checking the item vs the port
        if (!$item.hasClass('js-available') && $port.hasClass('js-available')) {
            var temp = $item;
            $item = $port;
            $port = temp;
        }

        $.ajax({
            url: $form.attr('action'),
            data: {
                newID: $item.data('item-id'),
                parentID: $port.data('parent-id'),
                portName: $port.data('port-id')
            },
            method: "POST",
            success: function (data) {
                $page = $(data);

                $('[id]').each(function () {

                    var $oldPane = $(this);

                    // Only act on deepest elements
                    if ($('[id]', $oldPane).length != 0) return
                    
                    var $newPane = $('#' + this.id, $page);

                    // Only act if pane exists in response
                    if ($newPane.length == 0) return;

                    var $newList = $('.cig-list', $newPane);
                    var $oldList = $('.cig-list', this);

                    if ($newList.length == 1 && $oldList.length == 1) {
                        // Preserve styling
                        $newList[0].className = $oldList[0].className;
                    }

                    // Replace with new method
                    $oldPane.replaceWith($newPane);
                });

                // Rebind events
                bindAll(document.body);
            }
        });
    }

    bindAll(document.body)
});