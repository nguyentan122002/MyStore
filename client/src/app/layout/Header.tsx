
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";

import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";


import { AppBar, Avatar, Badge, Box, IconButton, List, ListItem, Stack, Toolbar, Typography} from "@mui/material";

import { Link, NavLink } from "react-router-dom";
import { useStoreContext } from "../context/StoreContext";


const midLinks = [
  {title: 'Home', path: './'},
  {title: 'Shop', path: './catalog'},
  {title: 'About', path: './about'},
  {title: 'Contact', path: './contact'}
]

const rightLinks = [
  {title: 'Login', path: './login'},
  {title: 'Register', path: './register'},
]

const navStyle = {
  
  textDecoration: "none",
  color:"black",
  fontSize: 15,
  cursor: "pointer",
  transition: "1s linear",
  '&:hover': {
    color: '#AAAAAA',
    
  },
  '&.active':{
    color: '#000',
    borderBottom: '1px solid black', 

    

  }
}



export default function Header() {
  const {basket} = useStoreContext();
  const itemCount = basket?.items.reduce((sum,item) => sum + item.quantity, 0);

    return(
        <AppBar position="sticky" sx={{mb:0, backgroundColor: "white"}}>
            <Toolbar sx={{display: 'flex', justifyContent:'space-between', alignItems:'center'}}>

              <Box display='flex' alignItems='center'>
                <Stack direction="row" alignItems="center" spacing={2} sx={{mr:4}}>
                    <Avatar sx={{ width: 50, height: 50 }}>
                        <img src="../src/images/logo/logo.png" alt="" style={{ width: '100%', height: '100%', objectFit: 'cover' }} />
                    </Avatar>
                    <Typography  component={NavLink} to='./' sx={{ textDecoration: "none",color:"black",fontSize: 20,cursor: "pointer",}}>
                        MarchStudio
                    </Typography>
                </Stack>
              </Box>
                
              {/* tạo button truy cập các page about, shop, contact và router tới page */}
              <List sx={{display: 'flex', justifyContent:'center'}}>
                {midLinks.map(({title, path}) => 
                 <ListItem 
                    component={NavLink}
                    to = {path}
                    key={path}
                    sx={{...navStyle,marginRight: '15px',}}
                  >
                    {title.toUpperCase()}
                  </ListItem>
                  
                )}
              </List>
                  
              <Box display='flex' alignItems='center'>
                  {/* tạo button giỏ hàng */}
                <IconButton component={Link} to='/basket' size="medium" edge='start' sx={{mr: 2, color: "black"}}>
                  <Badge  badgeContent={itemCount} 
                          color="success"
                          sx={{
                              '&:hover': {color: 'rgba(85, 112, 106, 1)'
                          }} } >
                    <FontAwesomeIcon icon={faShoppingCart} />
                  </Badge>
                </IconButton>

                {/* tạo button login, register và router tới page */}
                <List sx={{display: 'flex', alignItems:'center', alignContent:'center'}}>
                  {rightLinks.map(({title, path}) => 
                    <ListItem 
                      component={NavLink}
                      to = {path}
                      key={path}
                      sx={navStyle}
                    >
                      {title.toUpperCase()}
                    </ListItem>
                  
                  )}
                </List>
              </Box>
                
            </Toolbar>
        </AppBar>
    );
}
