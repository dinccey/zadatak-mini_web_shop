import React, { Component } from "react";
import { Switch, Route, Link, BrowserRouter as Router } from "react-router-dom";
import axios from 'axios';
import jwt_decode from 'jwt-decode';

import AddProduct from './components/AddProduct';
import Cart from './components/Cart';
import ProductList from './components/ProductList';
import ProductItem from "./components/ProductItem";
import CheckOut from './components/CheckOut';

import Context from "./Context";


export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: null,
      cart: [],
      products: []
    };
    this.routerRef = React.createRef();
  }
  async componentDidMount() {
    let carts = await axios.get("https://localhost:5001/api/narudzba/kosarica");

    const products = await axios.get('https://localhost:5001/api/proizvod');
    //carts = products;
    console.log(products);
    //cart = cart ? JSON.parse(cart) : {};

    this.setState({ products: products.data, cart: carts.data.items });
  }
  addToCart = async (product) => {
    let products = this.state.products;
    let newProducts;
    //console.log(product);
    if(product.kolicina>0){
      let response = await axios.post("https://localhost:5001/api/narudzba/kosarica/add?id=" + product.id, product.id);
      var obj = products.find(item=> item.id === product.id);
      obj.kolicina = obj.kolicina -1;
      newProducts = products.map(p =>
        p.id === obj.id
          ? { ...p, kolicina: obj.kolicina }
          : p
      )
    }
    
    let carts = await axios.get("https://localhost:5001/api/narudzba/kosarica");
    
    this.setState({ cart: carts.data.items, products: newProducts });
  };

  removeFromCart = async (product) => {
    let products = this.state.products;
    let newProducts;
    var obj = products.find(item=> item.id === product.id);
      obj.kolicina = obj.kolicina +1;
      newProducts = products.map(p =>
        p.id === obj.id
          ? { ...p, kolicina: obj.kolicina }
          : p
      )
    let response = await axios.post("https://localhost:5001/api/narudzba/kosarica/remove?id=" + product.id, product.id);
    let carts = await axios.get("https://localhost:5001/api/narudzba/kosarica");
    console.log(product.id);
    this.setState({ cart: carts.data.items, products: newProducts });
  };

  checkout = () => {
    

  };
  

  render() {
    return (
      <Context.Provider
        value={{
          ...this.state,
          removeFromCart: this.removeFromCart,
          addToCart: this.addToCart,

          addProduct: this.addProduct,
          clearCart: this.clearCart,
          checkout: this.checkout
        }}
      >
        <Router ref={this.routerRef}>
          <div className="App">
            <nav
              className="navbar container"
              role="navigation"
              aria-label="main navigation"
            >
              <div className="navbar-brand">
                <b className="navbar-item is-size-4 ">MiniWebShop</b>
                <label
                  role="button"
                  class="navbar-burger burger"
                  aria-label="menu"
                  aria-expanded="false"
                  data-target="navbarBasicExample"
                  onClick={e => {
                    e.preventDefault();
                    this.setState({ showMenu: !this.state.showMenu });
                  }}
                >
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                  <span aria-hidden="true"></span>
                </label>
              </div>
              <div className={`navbar-menu ${this.state.showMenu ? "is-active" : ""
                }`}>
                <Link to="/products" className="navbar-item">
                  Products
                </Link>
                {this.state.user && this.state.user.accessLevel < 1 && (
                  <Link to="/add-product" className="navbar-item">
                    Add Product
                  </Link>
                )}
                <Link to="/cart" className="navbar-item">
                  Cart
                  <span
                    className="tag is-primary"
                    style={{ marginLeft: "5px" }}
                  >
                    {Object.keys(this.state.cart).length}
                  </span>
                </Link>

              </div>
            </nav>
            <Switch>
              <Route exact path="/" component={ProductList} />

              <Route exact path="/cart" component={Cart} />
              
              <Route exact path="/products" component={ProductList} />
              <Route exact path="/checkout" component={CheckOut} />
            </Switch>
          </div>
        </Router>
      </Context.Provider>
    );
  }
}
