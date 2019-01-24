<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <input type="text" v-model="search" class="form-control mb-5" placeholder="Search Keeps" />
        <li v-show="'search'.includes(filteredKeeps)"></li>
      </div>

    </div>

    <div class="row">
      <div class="card-columns count">
        <div v-for="keep in filteredKeeps">
          <div class="card">
            <button v-if="keep.userId == user.id" @click="deleteKeep(keep.id)" class="btn btn-sm icon mx-2"><i class="far fa-trash-alt"></i></button>
            <router-link :to="{name: 'keep', params: {keepId: keep.id, keep: keep}}">
              <img class="imgSize" :src='keep.img' height="250px">
              <p class="textSpace">Name: {{keep.name}}</p>
              <p class="textSpace">Description: {{keep.description}}</p>
            </router-link>
            <p class="textSpace"> <i class="far fa-eye"></i> {{keep.views}}</p>
            <!-- <p class="textSpace"> <i class="fas fa-share"></i> {{keep.shares}}</p> -->
            <p class="textSpace"> <i class="fab fa-kaggle"></i> {{keep.keeps}}</p>


            <div v-if="user.id" class="dropdown">
              <button class="btn btn-sm dropdown-toggle icon" type="button" id="dropdownMenuButton" data-toggle="dropdown"
                aria-haspopup="true" aria-expanded="false"><i class="fab fa-kaggle"> </i>
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <p class="dropdown-item action" v-for="vault in vaults" @click="addToVault(vault.id, keep, user)"
                  :vaultData="vault" v-bind:value="vault.id">{{vault.name}}</p>
              </div>
            </div>

          </div>
        </div>

      </div>
    </div>


  </div>



</template>

<script>
  export default {
    name: "home",
    props: ['keepId'],
    data() {
      return {
        search: ''
      }
    },
    mounted() {
      //blocks users not logged in
      // if (!this.$store.state.user.id) {
      //   this.$router.push({ name: "login" });
      // }
      this.$store.dispatch("getAllPublicKeeps"),
        this.$store.dispatch("getVaults")
    },

    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      keep() {
        return this.$store.state.activeKeep || ''
      },
      vaults() {
        return this.$store.state.vaults
      },
      filteredKeeps: function () {
        return this.keeps.filter((keep) => {
          return keep.name.toLowerCase().includes(this.search.toLowerCase())
        })
      },
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      addToVault(vaultId, keep, user) {
        let payload = {
          keepId: keep.id,
          vaultId: vaultId,
          userId: user.id
        }
        console.log(payload)
        this.$store.dispatch('addToVault', payload)
      },
      deleteKeep(keepId) {
        debugger
        this.$store.dispatch('deleteKeep', keepId)
      }

    }
  };
</script>
<style>
  .count {
    column-count: 4;
  }
</style>