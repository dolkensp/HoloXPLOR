
var checkRating = function () { };

$(document).ready(function () {
    var $form = $('#form-rating');

    if ($form.length == 0) return;

    var timeStep = 0.05;

    var shieldWeapon = function (shield, aggregate) {
        if (shield.HitPoints > 0) {
            var hp = shield.HitPoints;
            shield.HitPoints -= aggregate.Physical / shield.Physical_DamageAbsorbDirect;
            shield.HitPoints -= aggregate.Energy / shield.Energy_DamageAbsorbDirect;
            shield.HitPoints -= aggregate.Distortion / shield.Distortion_DamageAbsorbDirect;

            if (shield.HitPoints < 0) {
                var ratio = shield.HitPoints / (shield.HitPoints - hp);
                
                aggregate.Physical   = aggregate.Physical * ratio * shield.Physical_DamageAbsorbDirect;
                aggregate.Energy     = aggregate.Energy * ratio * shield.Energy_DamageAbsorbDirect;
                aggregate.Distortion = aggregate.Distortion * ratio * shield.Distortion_DamageAbsorbDirect;

                shield.HitPoints = 0;
            } else {
                aggregate.Physical = 0;
                aggregate.Energy = 0;
                aggregate.Distortion = 0;
            }
        }

        return aggregate;
    }

    var fireWeapon = function (weapon, aggregate) {
        if (weapon.Heat + weapon.HeatingRate < weapon.MaxHeat) {
            weapon.ShotsFired++;
            weapon.TotalDamage += weapon.Physical;
            weapon.TotalDamage += weapon.Energy;
            weapon.TotalDamage += weapon.Distortion;
            weapon.Heat += weapon.HeatingRate;

            aggregate.Physical += weapon.Physical;
            aggregate.Energy += weapon.Energy;
            aggregate.Distortion += weapon.Distortion;
        }

        return aggregate;
    }

    var attack = function (source, target, time, min_max) {
        if (target.Health <= 0)
            return;

        var aggregate = {
            Physical: 0,
            Energy: 0,
            Distortion: 0,
        };

        if (time > 0) {
            aggregate = {
                Physical: 0,
                Energy: 0,
                Distortion: 0,
            };

            for (var i = 0, j = source.Damage.length; i < j; i++) {
                if (source.Damage[i].ShotsFired == null)
                    source.Damage[i].ShotsFired = 0;

                if (source.Damage[i].TotalDamage == null)
                    source.Damage[i].TotalDamage = 0;

                if (source.Damage[i].ShotsChecked == null)
                    source.Damage[i].ShotsChecked = 0;

                if (source.Damage[i].Heat == null)
                    source.Damage[i].Heat = 0;

                source.Damage[i].Heat = Math.max(0, source.Damage[i].Heat - source.Damage[i].CoolingRate * timeStep);

                while (source.Damage[i].ShotsChecked < (time * source.Damage[i].Rate / 60)) {
                    source.Damage[i].ShotsChecked++;
                    fireWeapon(source.Damage[i], aggregate);
                }
            }
        }

        target.Shield = 0;

        if (target.Shields != null && target.Shields.length > 0) {
            for (var i = 0, j = target.Shields.length; i < j; i++) {
                if (target.Shields[i].HitPoints == null) {
                    if (min_max == "min") {
                        switch (target.Shields[i].FaceType) {
                            case "Quadrant":
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints / 4;
                                break;
                            case "FrontBack":
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints / 2;
                                break;
                            case "Bubble":
                            default:
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints;
                                break;
                        }
                    } else {
                        target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints;
                    }
                }

                // TODO: Need to only apply this if we can actually hold an opponent off one shield face completely
                // if (target.Shields[i].FaceType == "Quadrant" || target.Shields[i].FaceType == "FrontBack") {
                //     if (min_max != "min" &&
                //         target.Shields[i].HitPoints < target.Shields[i].MaxHitPoints &&
                //         time >= target.Shields[i].RegenDelay)
                //         target.Shields[i].HitPoints = Math.min(target.Shields[i].MaxHitPoints, target.Shields[i].HitPoints + target.Shields[i].MaxRegenRate * timeStep);
                // }

                shieldWeapon(target.Shields[i], aggregate);

                target.Shield += target.Shields[i].HitPoints;
            }
        }

        if (target.Shield == 0 && target.TTDS == null) {
            target.TTDS = time;
        }

        if (target.Armor != null) {
            aggregate.Physical = aggregate.Physical * target.Armor.Physical;
            aggregate.Energy = aggregate.Energy * target.Armor.Energy;
            aggregate.Distortion = aggregate.Distortion * target.Armor.Distortion;
        }

        if (time > 0) {
            target.Health -= aggregate.Physical;
            target.Health -= aggregate.Energy;
            target.Health -= aggregate.Distortion;

            if (target.Health <= 0 && target.TTK == null) {
                target.TTK = time;
                target.Health = 0;
            }
        }
    }

    checkRating = function () {
        $.ajax({
            url: $form[0].action,
            method: 'POST',
            data: { targetShip: $('#cig-rating').val() },
            dataType: 'json',
            success: function (data) {
                rating = data;


                var maxSelf = $.extend(true, { Health: data.Self.MaxHealth }, data.Self);
                var minSelf = $.extend(true, { Health: data.Self.MinHealth }, data.Self);
                var maxEnemy = $.extend(true, { Health: data.Enemy.MaxHealth }, data.Enemy);
                var minEnemy = $.extend(true, { Health: data.Enemy.MinHealth }, data.Enemy);

                var time = 0;
                var raw = []; // { self: self.Health, enemy: enemy.Health, time: time }];

                while ((maxSelf.Health > 0 || maxEnemy.Health > 0) && (time < 1800)) {
                    attack(maxSelf, maxEnemy, time);
                    attack(maxEnemy, maxSelf, time);

                    attack(minSelf, minEnemy, time, "min");
                    attack(minEnemy, minSelf, time, "min");

                    raw.push({
                        maxSelf: maxSelf.Health + maxSelf.Shield,
                        maxEnemy: maxEnemy.Health + maxEnemy.Shield,
                        minSelf: minSelf.Health + minSelf.Shield,
                        minEnemy: minEnemy.Health + minEnemy.Shield,
                        time: time
                    });

                    time += timeStep;
                }

                var margin = { top: 10, right: 10, bottom: 10, left: 10 },
                    width = 650,
                    height = 150;

                var color = d3.scale.category10();

                var x = d3.scale.linear().range([0, width]).domain([0, d3.max(raw, function (d) { return d.time })]);
                var y = d3.scale.linear().range([0, height]).domain([Math.max(d3.max(raw, function (d) { return d.maxSelf }), d3.max(raw, function (d) { return d.maxEnemy })), 0]);

                var xAxis = d3.svg.axis()
                    .scale(x)
                    .orient("bottom");

                var maxhealth_self = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { if (d.time <= maxSelf.TTK) return x(d.time); return x(maxSelf.TTK) })
                    .y(function (d) { if (d.time <= maxSelf.TTK) return y(d.maxSelf); return y(0) });

                var minhealth_self = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { if (d.time <= minSelf.TTK) return x(d.time); return x(minSelf.TTK) })
                    .y(function (d) { if (d.time <= minSelf.TTK) return y(d.minSelf); return y(0) });

                var maxhealth_enemy = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { if (d.time <= maxEnemy.TTK) return x(d.time); return x(maxEnemy.TTK) })
                    .y(function (d) { if (d.time <= maxEnemy.TTK) return y(d.maxEnemy); return y(0) });

                var minhealth_enemy = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { if (d.time <= minEnemy.TTK) return x(d.time); return x(minEnemy.TTK) })
                    .y(function (d) { if (d.time <= minEnemy.TTK) return y(d.minEnemy); return y(0) });

                $('#rating').empty();

                var svg = d3.select('#rating').append("svg")
                    .attr("viewbox", "0 0 " + (width + margin.left + margin.right) + " " + (height + margin.top + margin.bottom))
                    .attr("preserveAspectRatio", "xMidYMid meet")
                    .append("g")
                    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

                var graph = svg.selectAll(".graph")
                    .data([raw])
                    .enter().append("g")
                    .attr("class", "graph");

                graph.append("path")
                    .attr("class", "max-enemy")
                    .attr("d", function (d) { return maxhealth_enemy(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "max-self")
                    .attr("d", function (d) { return maxhealth_self(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "min-enemy")
                    .attr("d", function (d) { return minhealth_enemy(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "min-self")
                    .attr("d", function (d) { return minhealth_self(d); })
                    .style("fill", "none");

                // Hack for Chrome
                var $rating = $('#rating');

                var $table = $('<table class="table table-borderless table-striped table-condensed cig-table cig-table-2">');

                $table.append('<tr><th class=""></th><th class="cig-property">' + data.Self.DisplayName + '</th><th class="cig-property">' + data.Enemy.DisplayName + '</th></tr>');
                $table.append('<tr><th>TTK Shield</th><td>' + minSelf.TTDS.toFixed(2) + '-' + maxSelf.TTDS.toFixed(2) + 's</td><td>' + minEnemy.TTDS.toFixed(2) + '-' + maxEnemy.TTDS.toFixed(2) + 's</td></tr>');
                $table.append('<tr><th>TTK Hull</th><td>' + (minSelf.TTK - minSelf.TTDS).toFixed(2) + '-' + (maxSelf.TTK - maxSelf.TTDS).toFixed(2) + 's</td><td>' + (minEnemy.TTK - minEnemy.TTDS).toFixed(2) + '-' + (maxEnemy.TTK - maxEnemy.TTDS).toFixed(2) + 's</td></tr>');
                $table.append('<tr><th>Time To Kill</th><td>' + minSelf.TTK.toFixed(2) + '-' + maxSelf.TTK.toFixed(2) + 's</td><td>' + minEnemy.TTK.toFixed(2) + '-' + maxEnemy.TTK.toFixed(2) + 's</td></tr>');
                $table.append('<tr><th>Survivability</th>' +
                    '<td>' + ((((maxSelf.TTK - minSelf.TTK) / 2) + minSelf.TTK) / (((maxEnemy.TTK - minEnemy.TTK) / 2) + minEnemy.TTK) * 100).toFixed(0) + '%</td>' +
                    '<td>' + ((((maxEnemy.TTK - minEnemy.TTK) / 2) + minEnemy.TTK) / (((maxSelf.TTK - minSelf.TTK) / 2) + minSelf.TTK) * 100).toFixed(0) + '%</td>' +
                    '</tr>');

                $rating.append($table);
                $rating.html($rating.html());
            }
        });
    };

    checkRating();

    $("a[href='#specs']").on('shown.bs.tab', checkRating);
    // $('#cig-rating').on('change', checkRating);
});