<template>
  <div class="mainPage">
    <h2>Products</h2>
      <div id="products" v-for="product in products">
          <div id="basic-info">
            {{product.Id}} &nbsp;&nbsp; {{product.Name}} &nbsp;&nbsp;&nbsp; 
            <button v-on:click="toggleDetails(product.Id)">More details</button>
            </div>
            <div id="more-information" v-if="toggle && productToShow == product.Id">
                <br/>
                <div class="bold-text">Information</div>
                <div v-if="currentProduct !== null">
                    Id:&nbsp;{{currentProduct.Id}}<br/>
                    Name:&nbsp;{{currentProduct.Name}}<br/>
                    Description:&nbsp;{{currentProduct.Description}}<br/>
                    Price:&nbsp;{{currentProduct.Price}}<br/>
                    Weight:&nbsp;{{currentProduct.Weight}}<br/>
                    Is4G:&nbsp;{{currentProduct.Is4G}}<br/>
                </div>    
            </div>
      </div>
    <br/>
    <br/>
    <br/>
  </div>
</template>

<script>
import { BASE_URL } from './../variables.js';
export default {
    name: 'Main',
    data () {
        return {
        products: [],
        currentProduct: null,
        counter: 0,
        productToShow: null,
        toggle: false,
        }
    },
    methods: {
        toggleDetails: function(id){
        if (this.toggle && this.productToShow !== id)
        {
            this.toggle = true;
        }
        else
        {
            this.toggle = !this.toggle ;
        }
        this.productToShow = id;
        this.currentProduct = null;
        if (this.toggle)
        {
            this.fetchProduct(id);
        }
        },
        fetchProduct: function(id){
            this.$axios
            .get( BASE_URL + '/api/product/'+id )
            .then(response => (this.currentProduct = response.data))
            .catch((error) => {
                console.log(error.config);
            });
        }
    },
    mounted () {
        this.$axios
        .get( BASE_URL + '/api/product/')
        .then(response => (this.products = response.data))
        .catch((error) => {
            console.log(error.config);
        });
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

h2 {
    font-weight: 600;
}

a {
    color: #42b983;
}

.bold-text {
    font-weight: 600;
}

#products {
    font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
    width: 100%;
    border: 1px solid #ddd;
}

#basic-info {
    font-size:1.3em;
    padding: 10px;
}

#more-information {
    background: white;
    height: 140px;
    padding-top: 0px;
    padding-bottom: 30px;
}

</style>
