import React from "react";

const CartItem = props => {
  //const { cartItem } = props;

  const { product } = props;
  return (
    <div className=" column is-half">
      <div className="box">
        <div className="media">
          <div className="media-left">
            <figure className="image is-64x64">
              <img
                src="https://bulma.io/images/placeholders/128x128.png"
                alt={product.opis}
              />
            </figure>
          </div>
          <div className="media-content">
            <b style={{ textTransform: "capitalize" }}>
              {product.naziv}{" "}
              <span className="tag is-primary">${product.cijena}</span>
            </b>
            <div>{product.shortDesc}</div>
            
          </div>
          <div
            className="media-right"
            onClick={() => props.removeFromCart(product)}
          >
            <span className="delete is-large"></span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartItem;
