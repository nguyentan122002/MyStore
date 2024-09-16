import React from 'react';
import ReactDOM from 'react-dom/client';
import './app/layout/style.css';
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { RouterProvider } from 'react-router-dom';
import { router } from './app/router/routes.tsx'
import { StoreProvider } from './app/context/StoreContext.tsx';
import { configureStore } from './app/store/configureStore.ts';
import { Provider } from 'react-redux';

const store = configureStore();


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
  );

root.render(
  <React.StrictMode>
    <StoreProvider>
      <Provider store = {store}>
        <RouterProvider router={router} />
      </Provider>
    </StoreProvider>
  </React.StrictMode>,
  
)
