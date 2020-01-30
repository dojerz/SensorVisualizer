<template>
    <div>
        <p-check name="check" color="success">check</p-check>
        <chart :sensorvalues="humvalues" :domtarget="humdomtarget" class="humchart"></chart>
        <chart :sensorvalues="tempvalues" :domtarget="temperaturedomtarget" class="tempchart"></chart>
    </div>
</template>
<script>
    import Vue from 'vue';
    import chart from "./../components/chart.vue"
    import { getSensorData } from "./../services/dbServices"
    import PrettyCheckbox from 'pretty-checkbox-vue';

    Vue.use(PrettyCheckbox);

    export default {

        name: 'app-main',
        components: {
            chart
        },
        data() {
            return {
                humvalues: [],
                tempvalues: [],
                humdomtarget: ".humchart",
                temperaturedomtarget: ".tempchart"
            };
        },
        methods: {
            getData() {
                //return this.chartData;
                //console.log(this.chartData);
            },
            async getHumidityData() {
                try {
                    let result = await getSensorData('hum','1','3')
                    //this.chartData = result
                    this.humvalues = result
                    //this.tempvalues = result
                } catch (e) {
                    console.error(e);
                }
            },
            async getTemperatureData() {
                try {
                    let result = await getSensorData('temp', '1','3')
                    //this.chartData = result
                    this.tempvalues = result
                } catch (e) {
                    console.error(e);
                }
            }

        },
        //async created() {
        //    await axios.get('/api/SensorData/')
        //        .then(response => { this.chartData = response.data }).then(this.renderChart());
        //    console.log(this.chartData);
        //},
        mounted() {
            this.getHumidityData()
            this.getTemperatureData()
        }
    }
</script>
<style>
    /* REQUIRED */
    @import 'pretty-checkbox/scss/variables';
    @import 'pretty-checkbox/scss/core';


    /* OPTIONALS */

</style>