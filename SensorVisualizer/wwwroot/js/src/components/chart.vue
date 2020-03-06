<template>
    <div >
        {{domtarget}}
    </div>
</template>
<script>
    import MG from 'metrics-graphics';
    import 'metrics-graphics/dist/metricsgraphics.css';

    export default {
        name: 'app-chart',
        props: 
            ["sensorvalues", "domtarget"],
        data() {
            return {
                chart: null,
            }
        },
        watch: {
            sensorvalues(val) {
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
                    color: "#DADD98",
                    //interpolate: d3.curveCatmullRom.alpha(0),
                    //data: JSON.parse(JSON.stringify(this.testCData)),
                    //markers: [{ 'year': 1964, 'label': '"The Creeping Terror" released' }],
                    width: 650,
                    height: 400,
                    min_y: 18,
                    target: this.domtarget,//".result",
                    x_accessor: "date",
                    y_accessor: "value",
                    brush: 'x'
                });
            },
        },
        mounted() {
            //this.renderChart();
        }
    }
</script>