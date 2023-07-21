import { Fragment } from 'react';
import { Header } from './components/Header/Header';
import { Route, Routes } from 'react-router-dom';
import { Home } from './components/Home/Home';
import { Register } from './components/Register/Register';
import { Login } from './components/Login/Login';

function App() {
  return (
    <Fragment>
      <Header/>
      <main className='main'>
        <Routes>
          <Route path="/" element={<Home />}/>
          <Route path="/login" element={<Login />}/>
          <Route path="/register" element={<Register />}/>

        </Routes>
      </main>
    </Fragment>
  );
}

export default App;
