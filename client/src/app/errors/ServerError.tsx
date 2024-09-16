import { Container } from "@mui/material";


export default function ServerError() {
    // const {state}  = useLocation();
    const errorImage = './src/images/error/InternalServerError.png';

    return (
        <Container>
            {/* {state?.error ? (
                <>
                    <Typography gutterBottom variant="h3" color={"black"}>{state.error.title}</Typography>
                    <Divider/>
                    <Typography variant="body1">{state.error.detail || 'Internal server error'}</Typography>
                </>
            ) : (
            <Typography gutterBottom variant="h5" sx={{mt:2}}>Server Error</Typography>
            )} */}
            <img src={errorImage}  style={{ maxWidth: '100%', height: 'auto', marginTop: '-22px' }} />
        </Container>
    )
}