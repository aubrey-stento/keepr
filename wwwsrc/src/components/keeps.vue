<template>
    <div class="row">
        <div class="col-12">

            <!-- <h2>My Keeps</h2> -->
        </div>
        <div v-for="keep in keeps" @click="setActiveKeep(keep)" class="col-4" :key="keep._id">
            <div class="card">
                <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
                    <img :src="keep.img" height="200px">
                    <h1 class="card-title">{{keep.name}}</h1>
                </router-link>

                <button @click="deleteKeep(keep)"><i class="far fa-trash-alt"></i></button>
            </div>
        </div>

    </div>
</template>

<script>
    export default {
        name: 'Keeps',
        data() {
            return {

            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            }
        },
        mounted() {

            this.$store.dispatch('getKeepsByUserId', this.user.id)
        },
        methods: {
            setActiveKeep(keep) {
                this.$store.commit('setActiveKeep', keep)

            },
            deleteKeep(keep) {
                this.$store.dispatch('deleteKeep', keep)
            },
            getKeepsByUserId(userId) {
                this.$store.dipatch('getKeepsByUserId', userId)
            }
        },

    }

</script>

<style>


</style>