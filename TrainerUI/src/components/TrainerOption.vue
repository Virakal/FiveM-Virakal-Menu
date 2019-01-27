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
    .traineroption {
        display: flex;
        align-items: center;
        font-size: 16px;
        margin: 4px;
        color: white;
        height: 36px;
        width: 350px;
        background: rgba(0, 0, 0, 0.6);
        margin-top: -4px;
        padding-left: 5px;
    }

    .traineroption.trainertitle {
        justify-content: center;
        font-size: 25px;
        height: 75px;
        background: rgba(255, 64, 64, 0.8);
        text-shadow: 0 0 3px #e04040;
    }

    .traineroption.trainertitle:after {
        margin-left: 0;
        margin-right: 0;
    }

    .traineroption:after {
        content: attr(data-state);
        margin-left: auto;
        margin-right: 10px;
    }

    .traineroption[data-sub]:after {
        content: "»";
    }

    .traineroption.selected {
        background: rgba(255, 255, 255, 0.7);
        color: gray;
    }

    .traineroption.selected:after {
        content: attr(data-state);
    }

    .traineroption.selected[data-sub]:after {
        content: "»";
    }
</style>
