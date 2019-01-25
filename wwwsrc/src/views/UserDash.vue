<template>
    <div class="userDash">

        <div class="col-12">
            <h1> Welcome to your Dashboard {{user.username}}</h1>
        </div>

        <div class="col-12">

            <h2>My Vaults <i type="icon" class="icon fas fa-plus-circle" data-toggle="modal" data-target="#exampleModal"></i></h2>


            <!-- Modal -->
            <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
                aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Create a New Vault</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <VaultForm></VaultForm>
                            <!-- <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button> -->
                        </div>
                    </div>
                </div>
            </div>

            <Vaults></Vaults>
        </div>




        <h2>My Keeps <i type="icon" class="icon fas fa-plus-circle" data-toggle="modal" data-target="#exampleModal2"></i></h2>


        <!-- Modal -->
        <div class="modal fade" id="exampleModal2" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2"
            aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel2">Create a New Keep</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <KeepForm></KeepForm>
                    </div>
                </div>
            </div>
        </div>

        <!-- <VaultForm></VaultForm> -->
        <!-- <Vaults></Vaults> -->
        <!-- <KeepForm></KeepForm> -->
        <Keeps></Keeps>

    </div>
</template>

<script>
    import VaultForm from "@/components/createVault.vue";
    import Vaults from "@/components/vaults.vue";
    import KeepForm from "@/components/createKeep.vue";
    import Keeps from "@/components/keeps.vue";

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
            VaultForm,
            Vaults,
            KeepForm,
            Keeps
        }
    }

</script>

<style>
    i:hover {
        cursor: pointer;
    }
</style>