<template>
    <p class="traineroption" :data-sub="sub" :data-action="action" :data-state="state" :data-image="image">
        <slot></slot>
    </p>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class TrainerOption extends Vue {
        @Prop() private text!: string;
        @Prop() private sub!: string;
        @Prop() private action!: string;
        @Prop() private state!: string;
        @Prop() private image!: string;
    }
</script>

<style scoped>
</style>
