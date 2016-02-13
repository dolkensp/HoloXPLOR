var pause = {};

$(document).ready(function () {
    var debug = false;
    var $form = $('#form-ship');
    var $form_inventory = $('#form-inventory');

    if ($form.length == 0) return;

    var fadeTimer = null;
    var $source = null;

    var inventoryMap = {};
    var ammoMap = {};

    $.ajax({ url: $form_inventory[0].action, dataType: 'json', success: function (data) { inventoryMap = data.Inventory; ammoMap = data.Ammo } })
    
    var cleanValue = function(input)
    {
        if (input == null || input == undefined) return null;

        if (typeof input != "string") return input;

        if (input.startsWith("Ammo:")) input = "Ammunition";
        if (input.startsWith("Armor:")) input = "Armor";

        switch (input) {
            case 'FireAndForget': return 'Fire And Forget';
            case 'SignatureLock': return 'Signature Lock';
            case 'WeaponGun:NoseMounted': return 'Nose Mounted Gun';
            case 'WeaponGun:Gun':
            case 'WeaponGun': return 'Gun';
            case 'Turret:BallTurret': return 'Ball Turret';
            case 'Shield:': return 'Shield';
            case 'Turret:GunTurret':
            case 'Turret:Gun':
            case 'GimbalTurret':
            case 'GunTurret': return 'Gimbal';
            case 'Turret:MannedTurret': return 'Manned Turret';
            case 'Turret:CanardTurret':
            case 'CanardTurret': return 'Canard Turret';
            case 'Turret': return 'Gimbal / Turret';
            case 'Container:Cargo': return 'Cargo Container';
            case 'WeaponMissile:MissileRack':
            case 'WeaponMissile': return 'Missile Rack';
            case 'MainThruster:FixedThruster': return 'Engine';
            case 'ManneuverThruster:JointThruster':
            case 'ManneuverThruster:FlexThruster':
            case 'ManneuverThruster:FixedThruster':
            case 'ManneuverThruster': return 'Thruster';
            case 'PowerPlant:Power': return 'Power Plant';
            case 'Ordinance:Missile': return 'Missile';
            case 'AmmoBox:Ammo_CounterMeasure': return 'Counter Measure';
            default:
                input = input.replace('Paints', 'Paint');
                input = input.replace('Ordinance:', '');
                input = input.replace('AmmoBox:', '');
                input = input.replace('AmmoBox_', '');
                input = input.replace('Ammo_', '');
                input = input.replace(/_/gi, ' ');
                input = input.replace(/:/gi, ' ');
        }

        return input;
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

        if ($target.data('item-type') != undefined) {
            $markup.append('<p><strong>Type:</strong> ' + cleanType($target.data('item-type') + ':' + $target.data('item-sub-type') || '') + '</p>');
        }

        if ($target.data('port-types') != undefined) {
            var accepted = [];

            $.each($target.data('port-types').split(','), function () {
                var type = this;

                type = cleanType(type);

                accepted.push(type);
            });

            $markup.append('<p><strong>Accepted:</strong> ' + $.unique(accepted).join(', ') + '</p>');
        }

        return $markup;
    }

    var tableHeader = function (label, width, size) {
        size = size || 5;
        width = (width || 2) - 1;
        return $('<tr><th><h' + size + '>' + label + '</h' + size + '></th><th colspan=' + width + '></th></tr>');
    }

    var format = function (value, places) {
        if (value == undefined || value == null || value != value || value == 0)
            return null;

        places = places || 0;
        switch (typeof value) {
            case 'object':
                if (value.from == null && value.to == null)
                    return null;

                if (!isNaN(value.from) && !isNaN(value.to)) {
                    value = parseFloat(value.from).toFixed(places) + '-' + parseFloat(value.to).toFixed(places);
                } else {
                    value.from = value.from || null;
                    value.to = value.to || null;

                    if (value.from != null && value.to != null) {
                        value = value.from + '-' + value.to;
                    } else {
                        value = value.from || value.to;
                    }
                }
                break;
            case 'number':
                if (places > 0) {
                    value = value.toFixed(places);
                }
                break;
            case 'string':
                if (!isNaN(value) && places > 0) {
                    value = parseFloat(value).toFixed(places);
                }
                break;
        }
        return value;
    }

    var tableRow = function (label, equipped, available, places, unit) {

        // console.log(label, equipped, available, places, unit);

        if (equipped == null && available == null)
            return null;

        unit = unit || '';
        equipped = format(equipped, places);
        available = format(available, places);

        if (equipped == null && available == null)
            return;

        // console.log(label, equipped, available, places, unit);

        var $row = $('<tr>');
        $row.append('<th>' + label + '</th>');

        if (equipped != null)
            $row.append('<td>' + equipped.toLocaleString('en', { maximumFractionDigits: places, useGrouping: true }) + (equipped != '' ? unit : '') + '</td>');

        if (available != null)
            $row.append('<td>' + available.toLocaleString('en', { maximumFractionDigits: places, useGrouping: true }) + (available != '' ? unit : '') + '</td>');

        return $row;
    }

    var getComparison = function ($target, $source) {
        var enull = null;
        var anull = null;
        var azero = null;
        var ezero = null;
        var $port = null;
        var width = 1;

        if ($target != null && $target.data('port-name') != undefined) {
            $port = $target;
        }

        if ($source != null && $source.data('port-name') != undefined) {
            $port = $source;
        }

        if ($target != null && ($target.data('item-id') == undefined || $target.data('item-id') == '00000000-0000-0000-0000-000000000000')) {
            $target = null;
        }

        if ($source != null && ($source.data('item-id') == undefined || $source.data('item-id') == '00000000-0000-0000-0000-000000000000')) {
            $source = null;
        }

        if ($target == $source && $target != null) {
            if ($target.hasClass('js-available')) {
                $source = null;
            }
            else {
                $target = null;
            }
        }

        var $equipped = $target;
        var $available = $source;

        if (($source != null && $source.data('port-name') != undefined) || ($target != null && $target.data('port-name') == undefined)) {
            $equipped = $source;
            $available = $target;
        }

        var $header = $('<tr>');
        $header.append('<th class="cig-property">');
        if ($equipped != null || $available == null) {
            $header.append('<th class="cig-equipped">Equipped</th>');
            enull = '';
            ezero = 0.000000001;
            width++;
        }
        if ($available != null) {
            $header.append('<th class="cig-selected">Available</th>');
            anull = '';
            azero = 0.000000001;
            width++;
        }

        var $markup = $('<table class="table table-borderless table-striped table-condensed cig-table cig-table-' + width + '">');

        if ($equipped != null || $available != null) {
            $markup.append('<tr><th colspan="' + width + '"><h4>' + cleanValue(($equipped || $available).data('item-type') + ':' + (($equipped || $available).data('item-sub-type') || '')) + '</h4></th></tr>');
        } else {
            $markup.append('<tr><th colspan="2"><h4>Empty</h4></th></tr>');
        }


        if ($port != null) {
            if ($port.data('port-name') != undefined && $port.data('parent-name') != undefined) {
                $markup.append('<tr><td colspan="' + width + '">' + $port.data('parent-name') + ' - ' + $port.data('port-name') + '</td></tr>');
            } else {
                $markup.append('<tr><td colspan="' + width + '">' + $port.data('port-name') + '</td></tr>');
            }
        }

        $markup.append($header);

        $equipped = $equipped || { data: function () { } };
        $available = $available || { data: function () { } };

        if ($equipped.data('item-name') != undefined || $available.data('item-name') != undefined) {
            var equippedData = inventoryMap[$equipped.data('item-name')];
            var availableData = inventoryMap[$available.data('item-name')];

            if (equippedData != undefined || availableData != undefined) {
                equippedData = equippedData || {};
                availableData = availableData || {};

                $markup.append(tableRow(
                    'Name',
                    equippedData.DisplayName,
                    availableData.DisplayName));

                $markup.append(tableRow(
                    'Size',
                    $equipped.data('item-size'),
                    $available.data('item-size'),
                    0));

                if (equippedData.Armor != undefined || availableData.Armor != undefined) {
                    equippedData.Armor = equippedData.Armor || {};
                    availableData.Armor = availableData.Armor || {};
                    equippedData.Armor.DamageMultipliers = equippedData.Armor.DamageMultipliers || [{}];
                    availableData.Armor.DamageMultipliers = availableData.Armor.DamageMultipliers || [{}];

                    $markup.append(tableRow(
                        'Physical Res',
                        100 - equippedData.Armor.DamageMultipliers[0].Physical * 100,
                        100 - availableData.Armor.DamageMultipliers[0].Physical * 100,
                        0, '%'));
                    $markup.append(tableRow(
                        'Energy Res',
                        100 - equippedData.Armor.DamageMultipliers[0].Energy * 100,
                        100 - availableData.Armor.DamageMultipliers[0].Energy * 100,
                        0, '%'));
                    $markup.append(tableRow(
                        'Distortion Res',
                        100 - equippedData.Armor.DamageMultipliers[0].Distortion * 100,
                        100 - availableData.Armor.DamageMultipliers[0].Distortion * 100,
                        0, '%'));
                }

                if (equippedData.FireModes != undefined || availableData.FireModes != undefined) {
                    equippedData.FireModes = equippedData.FireModes || [];
                    availableData.FireModes = availableData.FireModes || [];

                    for (var i = 0, j = Math.max(equippedData.FireModes.length, availableData.FireModes.length) ; i < j; i++) {
                        equippedData.FireMode = equippedData.FireModes[i] || {};
                        availableData.FireMode = availableData.FireModes[i] || {};

                        equippedData.FireMode.Burst = equippedData.FireMode.Burst || {};
                        availableData.FireMode.Burst = availableData.FireMode.Burst || {};

                        $markup.append(tableHeader('Weapon', width));
                        $markup.append(tableRow(
                            'Fire Mode',
                            equippedData.FireMode.Type,
                            availableData.FireMode.Type));

                        if (equippedData.FireMode.Spread != undefined || availableData.FireMode.Spread != undefined) {
                            equippedData.FireMode.Spread = equippedData.FireMode.Spread || {};
                            availableData.FireMode.Spread = availableData.FireMode.Spread || {};

                            $markup.append(tableRow(
                                'Spread',
                                { from: equippedData.FireMode.Spread.Min, to: equippedData.FireMode.Spread.Max },
                                { from: availableData.FireMode.Spread.Min, to: availableData.FireMode.Spread.Max },
                                2, '&deg;'));
                        }
                        if (equippedData.FireMode.Fire != undefined || availableData.FireMode.Fire != undefined) {
                            equippedData.FireMode.Fire = equippedData.FireMode.Fire || {};
                            availableData.FireMode.Fire = availableData.FireMode.Fire || {};

                            equippedData.AmmoType = equippedData.AmmoType || [];
                            availableData.AmmoType = availableData.AmmoType || [];

                            equippedData.Ammo = ammoMap[equippedData.FireMode.Fire.AmmoType || equippedData.AmmoType[0]] || ammoMap[(inventoryMap[equippedData.FireMode.Fire.AmmoType || equippedData.AmmoType[0]] || { AmmoBox: {} }).AmmoBox.AmmoType] || {};
                            availableData.Ammo = ammoMap[availableData.FireMode.Fire.AmmoType || availableData.AmmoType[0]] || ammoMap[(inventoryMap[availableData.FireMode.Fire.AmmoType || availableData.AmmoType[0]] || { AmmoBox: {} }).AmmoBox.AmmoType] || {};

                            equippedData.Ammo.Explosion = equippedData.Ammo.Explosion || {};
                            availableData.Ammo.Explosion = availableData.Ammo.Explosion || {};

                            equippedData.Ammo.Physics = equippedData.Ammo.Physics || {};
                            availableData.Ammo.Physics = availableData.Ammo.Physics || {};

                            $markup.append(tableRow(
                                'Projectile Speed',
                                equippedData.Ammo.Physics.Speed,
                                availableData.Ammo.Physics.Speed,
                                0, ' mps'));

                            $markup.append(tableRow(
                                'Fire Rate',
                                (equippedData.FireMode.Burst.Rate * equippedData.FireMode.Burst.BurstSize) || equippedData.FireMode.Fire.Rate,
                                (availableData.FireMode.Burst.Rate * availableData.FireMode.Burst.BurstSize) || availableData.FireMode.Fire.Rate,
                                0, ' rpm'));

                            if (equippedData.Ammo.Damage_Physical || equippedData.Ammo.Explosion.Damage_Physical ||
                                availableData.Ammo.Damage_Physical || availableData.Ammo.Explosion.Damage_Physical)
                            {
                                $markup.append(tableRow(
                                    'Physical',
                                    (equippedData.Ammo.Damage_Physical || equippedData.Ammo.Explosion.Damage_Physical || ezero) * ((equippedData.FireMode.Burst.Rate * equippedData.FireMode.Burst.BurstSize) || equippedData.FireMode.Fire.Rate || ezero) / 60,
                                    (availableData.Ammo.Damage_Physical || availableData.Ammo.Explosion.Damage_Physical || azero) * ((availableData.FireMode.Burst.Rate * availableData.FireMode.Burst.BurstSize) || availableData.FireMode.Fire.Rate || azero) / 60,
                                    0, ' dps'));
                            }
                            if (equippedData.Ammo.Damage_Energy || equippedData.Ammo.Explosion.Damage_Energy ||
                                availableData.Ammo.Damage_Energy || availableData.Ammo.Explosion.Damage_Energy) {
                                $markup.append(tableRow(
                                    'Energy',
                                    (equippedData.Ammo.Damage_Energy || equippedData.Ammo.Explosion.Damage_Energy || ezero) * ((equippedData.FireMode.Burst.Rate * equippedData.FireMode.Burst.BurstSize) || equippedData.FireMode.Fire.Rate || ezero) / 60,
                                    (availableData.Ammo.Damage_Energy || availableData.Ammo.Explosion.Damage_Energy || azero) * ((availableData.FireMode.Burst.Rate * availableData.FireMode.Burst.BurstSize) || availableData.FireMode.Fire.Rate || ezero) / 60,
                                    0, ' dps'));
                            }
                            if (equippedData.Ammo.Damage_Distortion || equippedData.Ammo.Explosion.Damage_Distortion ||
                                availableData.Ammo.Damage_Distortion || availableData.Ammo.Explosion.Damage_Distortion)
                            {
                                $markup.append(tableRow(
                                    'Distortion',
                                    (equippedData.Ammo.Damage_Distortion || equippedData.Ammo.Explosion.Damage_Distortion || ezero) * ((equippedData.FireMode.Burst.Rate * equippedData.FireMode.Burst.BurstSize) || equippedData.FireMode.Fire.Rate || ezero) / 60,
                                    (availableData.Ammo.Damage_Distortion || availableData.Ammo.Explosion.Damage_Distortion || azero) * ((availableData.FireMode.Burst.Rate * availableData.FireMode.Burst.BurstSize) || availableData.FireMode.Fire.Rate || ezero) / 60,
                                    0, ' dps'));
                            }
                        }
                    }
                }

                if (equippedData.Missile != undefined || availableData.Missile != undefined) {
                    equippedData.Missile = equippedData.Missile || {};
                    availableData.Missile = availableData.Missile || {};

                    $markup.append(tableRow(
                        'Type',
                        cleanValue(equippedData.Missile.GuidanceType),
                        cleanValue(availableData.Missile.GuidanceType)));
                    $markup.append(tableRow(
                        'Proximity',
                        equippedData.Missile.ExplodeProximity || ezero,
                        availableData.Missile.ExplodeProximity || azero,
                        0, ' m'));
                }

                if (equippedData.Explosion != undefined || availableData.Explosion != undefined) {
                    equippedData.Explosion = equippedData.Explosion || {};
                    availableData.Explosion = availableData.Explosion || {};

                    $markup.append(tableHeader('Explosive', width));
                    $markup.append(tableRow(
                        'Radius',
                        equippedData.Explosion.MaxRadius,
                        availableData.Explosion.MaxRadius,
                        0, ' m'));
                    $markup.append(tableRow(
                        'Pressure',
                        equippedData.Explosion.Pressure,
                        availableData.Explosion.Pressure,
                        0, ' psi'));

                    if (equippedData.Explosion.Damage_Physical || availableData.Explosion.Damage_Physical) {
                        $markup.append(tableRow(
                            'Physical',
                            equippedData.Explosion.Damage_Physical || ezero,
                            availableData.Explosion.Damage_Physical || azero));
                    }
                    if (equippedData.Explosion.Damage_Energy || availableData.Explosion.Damage_Energy) {
                        $markup.append(tableRow(
                            'Energy',
                            equippedData.Explosion.Damage_Energy || ezero,
                            availableData.Explosion.Damage_Energy || azero));
                    }
                    if (equippedData.Explosion.Damage_Distortion || availableData.Explosion.Damage_Distortion) {
                        $markup.append(tableRow(
                            'Distortion',
                            equippedData.Explosion.Damage_Distortion || ezero,
                            availableData.Explosion.Damage_Distortion || azero));
                    }
                }

                if (equippedData.Shields != undefined || availableData.Shields != undefined) {
                    equippedData.Shields = equippedData.Shields || {};
                    availableData.Shields = availableData.Shields || {};

                    $markup.append(tableRow(
                        'Type',
                        equippedData.Shields.FaceType,
                        availableData.Shields.FaceType));
                    $markup.append(tableRow(
                        'Hit Points',
                        equippedData.Shields.MaxHitPoints,
                        availableData.Shields.MaxHitPoints,
                        0));
                    $markup.append(tableRow(
                        'Regen Rate',
                        equippedData.Shields.MaxRegenRate,
                        availableData.Shields.MaxRegenRate,
                        0));
                    $markup.append(tableRow(
                        'Regen Delay',
                        equippedData.Shields.RegenDelay,
                        availableData.Shields.RegenDelay,
                        0));

                    $markup.append(tableHeader('Physical', width));
                    $markup.append(tableRow(
                        'Damage Absorb',
                        equippedData.Shields.Physical_DamageAbsorbDirect,
                        availableData.Shields.Physical_DamageAbsorbDirect,
                        2));
                    $markup.append(tableRow(
                        'Splash Absorb',
                        equippedData.Shields.Physical_DamageAbsorbSplash,
                        availableData.Shields.Physical_DamageAbsorbSplash,
                        2));

                    $markup.append(tableHeader('Energy', width));
                    $markup.append(tableRow(
                        'Damage Absorb',
                        equippedData.Shields.Energy_DamageAbsorbDirect,
                        availableData.Shields.Energy_DamageAbsorbDirect,
                        2));
                    $markup.append(tableRow(
                        'Splash Absorb',
                        equippedData.Shields.Energy_DamageAbsorbSplash,
                        availableData.Shields.Energy_DamageAbsorbSplash,
                        2));

                    $markup.append(tableHeader('Distortion', width));
                    $markup.append(tableRow(
                        'Damage Absorb',
                        equippedData.Shields.Distortion_DamageAbsorbDirect,
                        availableData.Shields.Distortion_DamageAbsorbDirect,
                        2));
                    $markup.append(tableRow(
                        'Splash Absorb',
                        equippedData.Shields.Distortion_DamageAbsorbSplash,
                        availableData.Shields.Distortion_DamageAbsorbSplash,
                        2));
                }
            }
        }

        // $markup.append(getInfo($equipped));
        // 
        // if ($equipped != $available) {
        //     $markup.append(getInfo($available));
        // }

        return $markup;
    }

    var hideInfo = function (timeout) {
        return;
        window.clearTimeout(fadeTimer);
        fadeTimer = window.setTimeout(function () {
            var $markup = $('<div class="panel-body js-info">');

            if ($source != null) {
                $markup.append(getComparison($source));
            } else {
                $markup.html('Hover over an item to see more information');
            }

            $('.js-info').replaceWith($markup);
        }, timeout);
    };

    var showInfo = function ($target) {
        window.clearTimeout(fadeTimer);
        var $markup = $('<div class="panel-body js-info">');

        $markup.append(getComparison($target, $source));

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