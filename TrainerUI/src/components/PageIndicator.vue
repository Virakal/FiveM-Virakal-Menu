<template>
    <p class="pageindicator">Page {{ page + 1 }} of {{ pageCount }}</p>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class PageIndicator extends Vue {
        @Prop() private page!: number;
        @Prop() private pageCount!: number;
    }
</script>

<style scoped>
    .pageindicator {
        color: white;
        font-size: 20px;
        text-align: center;
    }
</style>
