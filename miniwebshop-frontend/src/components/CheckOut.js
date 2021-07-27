import React from "react";
import axios from 'axios';
import withContext from "../withContext";

const ProductList = props => {
  const { products } = props.context;

  this.state = {
    paymentMethods: []
  };
  const loadPaymentMethods = async () => {

    let methods = await axios.get("https://localhost:5001/api/narudzba/nacin_placanja");
    
    this.setState({ paymentMethods: methods.data });
  };
  
};

export default withContext(ProductList);
