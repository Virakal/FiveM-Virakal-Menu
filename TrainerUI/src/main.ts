import Vue from 'vue';
import Trainer from './Trainer.vue';

Vue.config.productionTip = true;

new Vue({
    render: h => h(Trainer)
}).$mount('#app');
