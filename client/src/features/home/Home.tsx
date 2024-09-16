import { Button } from '@mui/material'
import { Link } from 'react-router-dom'

export default function Homepage(){
    return(
        <div style={{ backgroundColor: '#ffffff', display: 'flex', justifyContent: 'center', alignItems: 'center', height: '86vh', width: '100%' }}>
            <div style={{ width: '65vh',
                          height: '65vh',
                          marginTop: '-120px', 
                          backgroundImage: 'url(./src/images/logo/Background.jpg)', 
                          backgroundSize: 'cover', 
                          backgroundPosition: 'center', 
                          borderRadius: '10px', 
                          display: 'flex', 
                          justifyContent: 'center', 
                          alignItems: 'center', 
                          position: 'relative' }}>
                <Button className="button" component={Link} to={'/catalog'}  sx={{
                    position: 'absolute', 
                    left: '50%', 
                    transform: 'translateX(-50%)', 
                    bottom: '-80px', 
                    width: '170px', 
                    height: '50px', 
                    backgroundColor: '#87A8A2',
                    border: 'none',
                    borderRadius: '10px',
                    fontSize:'18px',
                    cursor:'pointer',
                    transition:'background-color 0.3s',
                    color:'white', 
                    '&:hover': {color: 'rgba(85, 112, 106, 1)', border: '1px solid #87A8A2'}
                } }>
                            Buy now
                </Button>
            </div>

        </div>
    )
}
