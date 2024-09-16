import { Button, Container, Divider,  Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound(){
    return(
        <Container style={{height:400}}>
            <Typography>404</Typography>
            <Divider/>
            <Button component={Link} to = "/catalog" fullWidth> Go back the shop</Button>
        </Container>
    )
}