import { Fragment } from 'react';
import { Header } from './components/Header/Header';
import { Route, Routes } from 'react-router-dom';
import { Home } from './components/Home/Home';

function App() {
  return (
    <Fragment>
      <Header/>
      <main className='main'>
        <Routes>
          <Route path="/" element={<Home />}/>
        </Routes>
      </main>
    </Fragment>
  );
}

export default App;
