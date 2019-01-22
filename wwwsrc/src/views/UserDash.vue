<template>
    <div class="userDash">



        <VaultForm></VaultForm>

    </div>
</template>

<script>
    import VaultForm from "@/components/createVault.vue";
    export default {
        name: 'userDash',
        data() {
            return {

            }
        },
        computed: {
            user() {
                return this.$store.state.user
            }
        },
        methods: {},
        components: {
            VaultForm
        }
    }

</script>

<style>


</style>