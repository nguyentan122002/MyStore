import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { ChangeEvent, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Product } from "../../app/models/product";
import agent from "../../app/api/agent";
import NotFound from "../../app/errors/NotFound";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStoreContext } from "../../app/context/StoreContext";
import { LoadingButton } from "@mui/lab";


export default function ProductDetail(){
    const {basket, setBasket,removeItem} = useStoreContext();
    const {id} = useParams<{id: string}>();
    const [product, setProduct] =   useState<Product | null>(null);
    const [loading, setLoading] = useState(true);
    const [quantity, setQuantity] = useState(0);
    const [loadingSubmit, setLoadingSubmit] = useState(false);
    const item = basket?.items.find(i => i.productId === product?.id); 

    useEffect(() => {
        if (item) setQuantity(item.quantity);
        id && agent.Catalog.details(parseInt(id))
            .then(response => setProduct(response))
            .catch(error => console.log(error))
            .finally(() => setLoading(false));
    }, [id, item])

    function handleInputChange(event : ChangeEvent<HTMLInputElement>){
        if (parseInt(event.currentTarget.value) >= 0){
            setQuantity(parseInt(event.currentTarget.value));
        }
    }

    function handleUpdateCart(){
        if (!product) return;
        setLoadingSubmit(true);
        if (!item || quantity > item.quantity){
            const updateQuantity = item ? quantity - item.quantity : quantity;
            agent.Basket.addItem(product?.id, updateQuantity)
                        .then(basket => setBasket(basket))
                        .catch(error => console.log(error))
                        .finally(()=> setLoadingSubmit(false))
        }
        else{
            const updateQuantity = item.quantity - quantity;
            agent.Basket.removeItem(product?.id, updateQuantity)
                .then(() => removeItem(product?.id, updateQuantity))
                .catch(error => console.log(error))
                .finally(() => setLoadingSubmit(false))
        }
    }

    if (loading) return <LoadingComponent message="Loading product..."/>
    if (!product) return <NotFound/>

    return(
        <Grid container spacing={6} sx={{mt:2}}>
            <Grid item xs={6}>
                <img src= {product.pictureUrl} alt={product.name} style={{width: '100%'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant="h3">
                    {product.name}
                </Typography>
                <Divider sx={{mb: 2}} />
                <Typography variant="h5">
                    ${(product.price / 1000).toFixed(3)}
                </Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Name:</TableCell>
                                <TableCell>{product.name}</TableCell>
                            </TableRow>

                            <TableRow>
                                <TableCell>Description:</TableCell>
                                <TableCell>{product.description}</TableCell>
                            </TableRow>

                            <TableRow>
                                <TableCell>Type:</TableCell>
                                <TableCell>{product.type}</TableCell>
                            </TableRow>

                            <TableRow>
                                <TableCell>Brand:</TableCell>
                                <TableCell>{product.brand}</TableCell>
                            </TableRow>

                            <TableRow>
                                <TableCell>Quantity in stock:</TableCell>
                                <TableCell>{product.quantityInStock}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>

                <Grid container spacing={2}>
                    <Grid item xs={6}>
                        <TextField onChange={handleInputChange} variant="outlined" type="number" label="Quantity in cart" fullWidth value={quantity}/>    
                    </Grid>
                    <Grid item xs={6}>
                        <LoadingButton disabled={item?.quantity=== quantity || !item && quantity === 0} loading={loadingSubmit} onClick={handleUpdateCart} sx={{height:'55px'}} color="primary" size="large" variant="contained" fullWidth>
                            {item ? 'Update Quantity': 'Add to cart'}
                        </LoadingButton>
                    </Grid>
                </Grid>

            </Grid>
        </Grid>
    )
}