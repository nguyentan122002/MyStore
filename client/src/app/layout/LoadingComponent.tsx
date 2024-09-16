import { Backdrop, Box, CircularProgress, Typography } from "@mui/material";

interface Props{
    message?: string;
}
export default function LoadingComponent({message = 'Loading...'}:Props){
    return      (
        <Backdrop open={true} invisible={true}>
            <Box display='flex' justifyContent='center' alignItems='center' height='100vh'>
                <CircularProgress size={60} sx={{color:'#3B4947'}} />
                <Typography  sx={{justifyContent:'center', position:'fixed', top:'60%', color:'#3B4947', fontSize:'20px'}}>{message}</Typography>

            </Box>
        </Backdrop>
    )
}