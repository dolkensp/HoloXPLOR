
var checkRating = function () { };

$(document).ready(function () {
    var $form = $('#form-rating');

    if ($form.length == 0) return;

    var timeStep = 0.05;

    var shieldWeapon = function (shield, aggregate)
    {
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

    var fireWeapon = function(weapon, aggregate)
    {
        if (weapon.Heat + weapon.HeatingRate < weapon.MaxHeat) {
            weapon.ShotsFired++;
            weapon.Heat += weapon.HeatingRate;

            aggregate.Physical += weapon.Physical;
            aggregate.Energy += weapon.Energy;
            aggregate.Distortion += weapon.Distortion;
        }

        return aggregate;
    }

    var attack = function(source, target, time, min_max)
    {
        if (target.Health <= 0)
            return;

        var aggregate = {
            Physical: 0,
            Energy: 0,
            Distortion: 0,
        };

        if (time > 0) {
            for (var i = 0, j = source.Damage.length; i < j; i++) {
                aggregate = {
                    Physical: 0,
                    Energy: 0,
                    Distortion: 0,
                };

                if (source.Damage[i].ShotsFired == null)
                    source.Damage[i].ShotsFired = 0;

                if (source.Damage[i].ShotsChecked == null)
                    source.Damage[i].ShotsChecked = 0;

                if (source.Damage[i].Heat == null)
                    source.Damage[i].Heat = 0;

                source.Damage[i].Heat = Math.max(0, source.Damage[i].Heat - source.Damage[i].CoolingRate * timeStep);

                console.log(source.Damage[i].ShotsChecked, time, source.Damage[i].Rate / 60);

                while (source.Damage[i].ShotsChecked < (time * source.Damage[i].Rate / 60)) {
                    source.Damage[i].ShotsChecked++;
                    fireWeapon(source.Damage[i], aggregate);
                }
            }
        }

        // if (min_max == "min") {
        //     console.log('Shield', source.DisplayName, source.Damage.length, 'Guns', (aggregate.Physical + aggregate.Energy + aggregate.Distortion), 'Damage', target.Shield, target.Health);
        // }

        target.Shield = 0;

        if (target.Shields != null && target.Shields.length > 0) {
            for (var i = 0, j = target.Shields.length; i < j; i++) {
                if (target.Shields[i].HitPoints == null) {
                    if (min_max == "min") {
                        switch (target.Shields[i].FaceType)
                        {
                            case "Quadrant":
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints / 4;
                                break;
                            case "FrontBack":
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints / 2;
                                break;
                            default:
                                target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints;
                                break;
                        }
                    } else {
                        target.Shields[i].HitPoints = target.Shields[i].MaxHitPoints;
                    }
                }

                // if (target.Shields[i].HitPoints < target.Shields[i].MaxHitPoints)
                //     target.Shields[i].HitPoints = Math.min(target.Shields[i].MaxHitPoints, target.Shields[i].HitPoints + target.Shields[i].MaxRegenRate);

                shieldWeapon(target.Shields[i], aggregate);

                target.Shield += target.Shields[i].HitPoints;
            }
        }

        // console.log('Armor', source.DisplayName, source.Damage.length, 'Guns', (aggregate.Physical + aggregate.Energy + aggregate.Distortion), 'Damage');

        if (target.Armor != null) {
            aggregate.Physical = aggregate.Physical * target.Armor.Physical;
            aggregate.Energy = aggregate.Energy * target.Armor.Energy;
            aggregate.Distortion = aggregate.Distortion * target.Armor.Distortion;
        }

        if (time > 0) {
            target.Health -= aggregate.Physical;
            target.Health -= aggregate.Energy;
            target.Health -= aggregate.Distortion;

            if (target.Health < 0 && target.TTK == null)
            {
                target.TTK = time;
                target.Health = Math.max(0, target.Health);
            }
        }
    }

    checkRating = function () {
        $.ajax({
            url: $form[0].action,
            method: 'POST',
            data: { targetShip: $('#cig-rating').val() },
            // data: { targetShip: 'AEGS_Retaliator' },
            dataType: 'json',
            success: function (data) {
                rating = data;

                
                var maxSelf1 = $.extend(true, { Health: data.Self.MaxHealth }, data.Self);
                var minSelf1 = $.extend(true, { Health: data.Self.MinHealth }, data.Self);
                var maxEnemy1 = $.extend(true, { Health: data.Enemy.MaxHealth }, data.Enemy);
                var minEnemy1 = $.extend(true, { Health: data.Enemy.MinHealth }, data.Enemy);

                var maxSelf2 = $.extend(true, { Health: data.Self.MaxHealth }, data.Self);
                var minSelf2 = $.extend(true, { Health: data.Self.MinHealth }, data.Self);
                var maxEnemy2 = $.extend(true, { Health: data.Enemy.MaxHealth }, data.Enemy);
                var minEnemy2 = $.extend(true, { Health: data.Enemy.MinHealth }, data.Enemy);

                var time = 0;
                var raw = []; // { self: self.Health, enemy: enemy.Health, time: time }];

                while ((maxSelf2.Health > 0 || maxEnemy2.Health > 0) && (time < 1800)) {
                    attack(maxSelf1, maxEnemy2, time);
                    attack(maxEnemy1, maxSelf2, time);

                    attack(minSelf1, minEnemy2, time, "min");
                    attack(minEnemy1, minSelf2, time, "min");

                    raw.push({
                        maxSelf: maxSelf2.Health + maxSelf2.Shield,
                        maxEnemy: maxEnemy2.Health + maxEnemy2.Shield,
                        minSelf: minSelf2.Health + minSelf2.Shield,
                        minEnemy: minEnemy2.Health + minEnemy2.Shield,
                        time: time
                    });

                    time += timeStep;
                }

                console.log(maxSelf2, maxEnemy2, minSelf2, minEnemy2);

                var margin = { top: 10, right: 10, bottom: 10, left: 10 },
                    width = 650,
                    height = 200;

                var color = d3.scale.category10();

                var x = d3.scale.linear().range([0, width]).domain([0, d3.max(raw, function(d) { return d.time })]);
                var y = d3.scale.linear().range([0, height]).domain([Math.max(d3.max(raw, function (d) { return d.maxSelf }), d3.max(raw, function (d) { return d.maxEnemy })), 0]);

                var xAxis = d3.svg.axis()
                    .scale(x)
                    .orient("bottom");

                var maxhealth_self = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { return x(d.time); })
                    .y(function (d) { return y(d.maxSelf); });

                var minhealth_self = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { return x(d.time); })
                    .y(function (d) { return y(d.minSelf); });

                var maxhealth_enemy = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { return x(d.time); })
                    .y(function (d) { return y(d.maxEnemy); });

                var minhealth_enemy = d3.svg.line()
                    .interpolate("monotone")
                    .x(function (d) { return x(d.time); })
                    .y(function (d) { return y(d.minEnemy); });

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
                    .attr("class", "max-self")
                    .attr("d", function (d) { return maxhealth_self(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "min-self")
                    .attr("d", function (d) { return minhealth_self(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "max-enemy")
                    .attr("d", function (d) { return maxhealth_enemy(d); })
                    .style("fill", "none");

                graph.append("path")
                    .attr("class", "min-enemy")
                    .attr("d", function (d) { return minhealth_enemy(d); })
                    .style("fill", "none");

                // Hack for Chrome
                var $rating = $('#rating');
                $rating.html($rating.html());
            }
        });
    };

    checkRating();

    $("a[href='#specs']").on('shown.bs.tab', checkRating);
    // $('#cig-rating').on('change', checkRating);
});