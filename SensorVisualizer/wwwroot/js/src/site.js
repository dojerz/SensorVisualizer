import App from './components/app.vue';
import Vue from 'vue';

new Vue({
    el: '#app',
    render: h => h(App),
    methods: {
    },
    mounted() {
        console.log('site.js AppPrivate mounted!');
        //let startapp = init();
    }
});