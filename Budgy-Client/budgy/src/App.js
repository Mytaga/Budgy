import { Fragment } from 'react';
import { Route, Routes } from 'react-router-dom';

import { Header } from './components/Header/Header';
import { Home } from './components/Home/Home';
import { Register } from './components/Register/Register';
import { Login } from './components/Login/Login';
import { Logout } from './components/Logout/Logout';
import { AuthProvider } from './contexts/AuthContext';
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
            <Route path="/transactions" element={<TransactionList />} />
            <Route path="/create" element={<CreateTransaction />} />
            <Route path="/delete" element={<DeleteTransaction />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/logout" element={<Logout />} />
          </Routes>
        </main>
      </Fragment>
    </AuthProvider>
  );
}

export default App;
