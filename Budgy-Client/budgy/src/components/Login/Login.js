import { Form, Button } from "react-bootstrap";
import { ErrorToast } from "../Errors/ErrorToast";
import { useContext } from "react";
import { useForm } from "../../hooks/useForm";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";

import styles from '../Login/Login.module.css';

export const Login = () => {

    const { onLoginSubmit, showError, onErrorClose, errorMessage } = useContext(AuthContext);

    const { formValues, formChangeHandler, onSubmit } = useForm({ email: '', password: '' }, onLoginSubmit);

    return (
        <div className={styles['wrapper']}>
            <ErrorToast
                show={showError}
                close={onErrorClose}
                errorMessage={errorMessage}
            />
            <Form className={styles['login-form']} onSubmit={onSubmit} method="POST">
                <h3 className={styles['header']}>Sign In</h3>
                <Form.Group className={`${styles['login-group']} mb-3`}>
                    <Form.Label className={styles['login-label']}>Email address</Form.Label>
                    <Form.Control
                        type="text"
                        id="login"
                        name="email"
                        placeholder="Email"
                        value={formValues.email}
                        onChange={formChangeHandler} />
                </Form.Group>
                <Form.Group className={`${styles['login-group']} mb-3`}>
                    <Form.Label className={styles['login-label']}>Password</Form.Label>
                    <Form.Control
                        type="text"
                        id="password"
                        name="password"
                        placeholder="Password"
                        value={formValues.password}
                        onChange={formChangeHandler} />
                </Form.Group>
                <Button className={styles['submit-btn']} variant="transparent" type="submit">
                    Submit
                </Button>
                <div className={styles['form-footer']}>
                    <Link className={styles['footer-text']} to={'/forgot'}>Forgot Password?</Link>
                </div>
            </Form>
        </div>
    );
};