import { Navigate, createBrowserRouter } from "react-router-dom"; 
import App from "../layout/App";
import Homepage from "../../features/home/Home";
import Catalog from "../../features/catalog/catalog";
import ProductDetail from "../../features/catalog/ProductDetail";
import AboutPage from "../../features/about/AboutPage";
import ContactPage from "../../features/contact/ContactPage";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import BasketPage from "../../features/basket/BasketPage";
import CheckoutPage from "../../features/checkout/CheckoutPage";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children:[
            {path:'',element:<Homepage/>},
            {path:'catalog',element:<Catalog/>},
            {path:'catalog/:id',element:<ProductDetail/>},
            {path:'about',element:<AboutPage/>},
            {path:'contact',element:<ContactPage/>},
            {path:'server-error',element:<ServerError/>},
            {path:'not-found',element:<NotFound/>},
            {path:'basket',element:<BasketPage />},
            {path:'checkout',element:<CheckoutPage />},
            {path:'*',element:<Navigate replace to = '/not-found'/>},


        ]
    }
])