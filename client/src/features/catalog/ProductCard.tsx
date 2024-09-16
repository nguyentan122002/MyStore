import {  Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Product } from "../../app/models/product";
import { Link } from "react-router-dom";
import { useState } from "react";
import agent from "../../app/api/agent";
import { LoadingButton } from "@mui/lab";
import { useStoreContext } from "../../app/context/StoreContext";
import { currencyFormat } from "../../app/util/util";


interface Props{
    product: Product;
}

export default function ProductCart({product}: Props){
  const [loading, setLoading] = useState(false);
  const {setBasket} = useStoreContext();

  function handleAddItem(productId : number) {
    setLoading(true);
    agent.Basket.addItem(productId)
                .then(basket => setBasket(basket))
                .catch(error => console.log(error))
                .finally(() => setLoading(false));
  }

    return(
        <Card sx={{ maxWidth: 345, borderRadius: 3, mt:2, mb:2 }}>
        <CardHeader
          // avatar={
          //   <Avatar>
          //     {product.name.charAt(0).toUpperCase()}
          //   </Avatar>
          // }
          title={product.name} 
          titleTypographyProps={
            {
              sx: {fontWeight: 'bold', color: ''}
            }
          }
        />
        <CardMedia
          sx={{backgroundSize: 'contain'}}
          component="img"
          alt="green iguana"
          height="170"
          image={product.pictureUrl}
          title={product.name}
        />
        <CardContent>
          <Typography gutterBottom color='' variant="h6">
            {currencyFormat(product.price)}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {product.brand} / {product.type}
          </Typography>
        </CardContent>
        <CardActions>
          <LoadingButton loading={loading} onClick={() => handleAddItem(product.id)} size="small">Add to cart</LoadingButton>
          <Button component={Link} to={`/catalog/${product.id}`} size="small">View</Button>
        </CardActions>
      </Card>
    )
}