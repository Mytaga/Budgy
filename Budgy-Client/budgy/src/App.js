import { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';

import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Register } from './components/Register/Register';
import { Login } from './components/Login/Login';
import { Logout } from './components/Logout/Logout';
import { AuthProvider } from './contexts/AuthContext';
import { NonAuthGuard } from './components/RouteGuards/NonAuthGuard';
import { AuthGuard } from './components/RouteGuards/AuthGuard';
import { TransactionList } from './components/TransactionList/TransactionList';
import { CreateTransaction } from './components/Transaction/CreateTransaction';
import { DeleteTransaction } from './components/Transaction/DeleteTransaction';

function App() {
  return (
    <AuthProvider>
      <Fragment>
        <Header />
        <main className='main'>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/transactions" element={
              <AuthGuard>
                <TransactionList />
              </AuthGuard>
            } />
            <Route path="/create" element={
              <AuthGuard>
                <CreateTransaction />
              </AuthGuard>
            } />
            <Route path="/delete" element={<DeleteTransaction />} />
            <Route path="/login" element={
              <NonAuthGuard>
                <Login />
              </NonAuthGuard>
            } />
            <Route path="/register" element={
              <NonAuthGuard>
                <Register />
              </NonAuthGuard>
            } />
            <Route path="/logout" element={
              <AuthGuard>
                <Logout />
              </AuthGuard>
            } />
          </Routes>
        </main>
      </Fragment>
    </AuthProvider>
  );
}

export default App;
