import Vue from 'vue';
import Trainer from './Trainer.vue';

Vue.config.productionTip = true;
console.log("Rendering:");
new Vue({
    render: h => h(Trainer)
}).$mount('#app');
console.log("Rendered.");
