<template>
    <div class="keep container">
        <div class="row">
            <div class="col-8 card">
                <p>Name: {{keep.name}}</p>
                <p>Description: {{keep.description}}</p>
                <img :src="keep.image">
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        name: 'keep',
        props: ['keepId'],
        data() {
            return {
                keepData: {}
            }
        },
        mounted() {
            this.$store.dispatch("getKeepById", this.$route.params.keepId)
        },
        computed: {
            keep() {
                return this.$store.state.activeKeep || ''
            },
            user() {
                return this.$store.state.user
            }
        }
    }
</script>