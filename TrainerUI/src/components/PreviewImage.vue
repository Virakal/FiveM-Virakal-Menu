<template>
    <div class="imagecontainer" v-if="img">
        <img :src="img">
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class PreviewImage extends Vue {
        @Prop() private img!: string;
    }
</script>

<style scoped>
    .imagecontainer {
        opacity: 0.7;
        position: absolute;
        right: 650px;
        top: 100px;
    }

    img {
        border: 1px solid black;
        margin: 0;
        max-width: 350px;
        padding: 0;
        width: 350px;
    }
</style>
