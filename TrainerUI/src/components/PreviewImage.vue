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
        position: absolute;
        top: 100px;
        right: 650px;
        border: 1px solid black;
    }

    img {
        width: 200px;
        max-width: 200px;
    }
</style>
