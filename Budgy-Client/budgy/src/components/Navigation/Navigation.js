import { NavDropdown, Nav, Navbar, Container } from 'react-bootstrap'
import { Link } from 'react-router-dom';
import { useContext } from 'react';
import { AuthContext } from '../../contexts/AuthContext';
import styles from "../Navigation/Navigation.module.css";


export const Navigation = () => {

  const { isAuthenticated } = useContext(AuthContext);

  return (
    <Navbar collapseOnSelect expand="lg" className={`${styles['navbar']} bg-body-tertiary`}>
      <Container>
        <Navbar.Brand>
          <Link to={"/"} className={`${styles['icons-logo']} navbar-brand mt-2 mt-lg-0`}>BUDGY</Link>
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
        <Navbar.Collapse id="responsive-navbar-nav">
          <Nav className={`${styles['navbar-links']} me-auto`}>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Home</Link>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Wallet</Link>
            <NavDropdown title={<span className={styles['icons']}>Transactions</span>} id="collasible-nav-dropdown">
              <NavDropdown.Item className={styles['icons']}>
                <Link to={"/create"} className={`${styles['icons']} nav-link`}>
                  Make Transaction
                </Link>
              </NavDropdown.Item>
              <NavDropdown.Item className={styles['icons']}>
                <Link to={"/transactions"} className={`${styles['icons']} nav-link`}>
                  Transaction History
                </Link>
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item className={styles['icons']}>
                <Link to={"/delete"} className={`${styles['icons']} nav-link`}>
                  Reset Transaction
                </Link>
              </NavDropdown.Item>
            </NavDropdown>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Credits and loans</Link>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Crypto</Link>
          </Nav>
          <Nav className={styles['navbar-links']}>
            {!isAuthenticated && (<Link to={"/login"} className={`${styles['icons']} nav-link`}>Login</Link>)}
            {!isAuthenticated && (<Link to={"/register"} className={`${styles['icons']} nav-link`}>Register</Link>)}
            {isAuthenticated && (<Link to={"/profile"} className={`${styles['icons']} nav-link`}>Profile</Link>)}
            {isAuthenticated && (<Link to={"/logout"} className={`${styles['icons']} nav-link`}>Logout</Link>)}
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}