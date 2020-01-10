<template>
    <div class="result">
        kisfaszom
    </div>
</template>
<script>
    import MG from 'metrics-graphics';
    import 'metrics-graphics/dist/metricsgraphics.css';

    export default {
        name: 'app-chart',
        props: ["issues"],
        data() {
            return {
                chart: null,
                testCData: [{ 'year': '1945', 'sightings': 6 }, { 'year': '1947', 'sightings': 10 }]
            }
        },
        watch: {
            issues(val) {
                console.log('loaded');
                //console.log(val);
                this.renderChart(val);
            }
        },
        methods: {
            renderChart(cdata) {
                let converteddata = MG.convert.date(cdata.data, "date", "%Y-%m-%d.%H:%M:%S");
                this.chart = MG.data_graphic({
                    
                    //title: "UFO Sightings",
                    //description: "Yearly UFO sightings from 1945 to 2010.",
                    //data: JSON.parse(JSON.stringify(this.chartData)),
                    data: converteddata,// JSON.parse(JSON.stringify(issues.data)),
                    animate_on_load: true,
                    //data: JSON.parse(JSON.stringify(this.testCData)),
                    //markers: [{ 'year': 1964, 'label': '"The Creeping Terror" released' }],
                    width: 800,
                    height: 500,
                    min_y: 18,
                    target: ".result",
                    x_accessor: "date",
                    y_accessor: "value",
                    brush: 'x'
                });
            },
        },
        mounted() {
            this.renderChart();
        }
    }
</script>