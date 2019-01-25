<template>
    <div class="keepForm">
        <form @submit.prevent="createKeep">
            <div class="form-group">
                <input class="form-control" type="text" placeholder="Name" v-model="keepData.name">
                <input class="form-control" type="text" placeholder="Description" v-model="keepData.description">
                <input class="form-control" type="img" placeholder="Image Url" v-model="keepData.img">
                <!-- <input class="form-control" type="text" placeholder="Description" v-model="vaultData.description"> -->
                <button type="submit" class="btn btn-sm btn-info">Create Keep</button>
            </div>
        </form>

    </div>
</template>

<script>
    export default {
        name: 'KeepForm',
        data() {
            return {
                keepData: {
                    name: '',
                    description: '',
                    img: '',
                    isPrivate: 0
                }
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            user() {
                return this.$store.state.user
            }
        },
        methods: {

            createKeep() {
                this.$store.dispatch('createKeep', this.keepData)
                this.$store.dispatch('getKeepsByUserId', this.user)

            }
        }

    }

</script>

<style>


</style>