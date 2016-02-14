
$(document).ready(function () {
    var $form = $('#form-rating');

    if ($form.length == 0) return;

    $.ajax({
        url: $form[0].action,
        method: 'POST',
        data: { targetShip: 'ANVL_Hornet_F7CM' },
        dataType: 'json',
        success: function (data) {
            rating = data;
            
            var raw = [
                { self: 100, enemy: 200, time:  0 },
                { self: 95,  enemy: 180, time:  1 },
                { self: 90,  enemy: 160, time:  2 },
                { self: 85,  enemy: 140, time:  3 },
                { self: 80,  enemy: 120, time:  4 },
                { self: 75,  enemy: 100, time:  5 },
                { self: 70,  enemy:  92, time:  6 },
                { self: 65,  enemy:  84, time:  7 },
                { self: 60,  enemy:  72, time:  8 },
                { self: 55,  enemy:  64, time:  9 },
                { self: 50,  enemy:  56, time: 10 },
                { self: 45,  enemy:  48, time: 11 },
                { self: 40,  enemy:  40, time: 12 },
                { self: 35,  enemy:  32, time: 13 },
                { self: 30,  enemy:  24, time: 14 },
                { self: 25,  enemy:  16, time: 15 },
                { self: 20,  enemy:   8, time: 16 },
                { self: 15,  enemy:   0, time: 17 },
                { self: 10,  enemy:   0, time: 18 },
                { self:  5,  enemy:   0, time: 19 },
                { self:  0,  enemy:   0, time: 20 },
            ];

            var width = 800,
                height = 600;

            var color = d3.scale.category10();

            var x = d3.scale.linear().range([0, width]).domain([0, raw.length - 1]);
            var selfY = d3.scale.linear().range([0, height]).domain([d3.max(raw, function (d) { return d.self }), 0]);
            var enemyY = d3.scale.linear().range([0, height]).domain([d3.max(raw, function (d) { return d.enemy }), 0]);

            var health_self = d3.svg.line()
                .interpolate("monotone")
                .x(function (d) { return x(d.time); })
                .y(function (d) { return selfY(d.self); });

            var health_enemy = d3.svg.line()
                .interpolate("monotone")
                .x(function (d) { return x(d.time); })
                .y(function (d) { return enemyY(d.enemy); });

            var svg = d3.select('#rating').append("svg")
                .attr("viewbox", "0 0 " + width + " " + height)
                .attr("preserveAspectRatio", "xMidYMid meet")
                //.attr("width", width)
                //.attr("height", height)
                //.attr("background", "#fff")
                .append("g");

            var graph = svg.selectAll(".graph")
                .data([ raw ])
                .enter().append("g")
                .attr("class", "graph");

            graph.append("path")
                .attr("class", "self")
                .attr("d", function (d) { return health_self(d); })
                .style("fill", "none")
                .style("stroke", function (d) { return color("self"); });

            graph.append("path")
                .attr("class", "enemy")
                .attr("d", function (d) { return health_enemy(d); })
                .style("fill", "none")
                .style("stroke", function (d) { return color("enemy"); });

            var $rating = $('#rating');
            $rating.html($rating.html());
        }
    });
});