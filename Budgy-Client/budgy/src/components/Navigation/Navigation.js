import { NavDropdown, Nav, Navbar, Container } from 'react-bootstrap'
import { Link } from 'react-router-dom';
import styles from "../Navigation/Navigation.module.css";


export const Navigation = () => {
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
                Make Transaction
              </NavDropdown.Item>
              <NavDropdown.Item className={styles['icons']}>
                Transaction History
              </NavDropdown.Item>
              <NavDropdown.Divider />
              <NavDropdown.Item className={styles['icons']}>
                Reset Transactionss
              </NavDropdown.Item>
            </NavDropdown>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Credits and loans</Link>
            <Link to={"/"} className={`${styles['icons']} nav-link`}>Crypto</Link>
          </Nav>
          <Nav className={styles['navbar-links']}>
            <Link to={"/login"} className={`${styles['icons']} nav-link`}>Login</Link>
            <Link to={"/register"} className={`${styles['icons']} nav-link`}>Register</Link>
            <Link to={"/profile"} className={`${styles['icons']} nav-link`}>Profile</Link>
            <Link to={"/logout"} className={`${styles['icons']} nav-link`}>Logout</Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}