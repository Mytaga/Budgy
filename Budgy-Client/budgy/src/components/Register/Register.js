import { Form, Button } from "react-bootstrap";
import { useState, useContext } from "react";
import { AuthContext } from '../../contexts/AuthContext';
import { useForm } from "../../hooks/useForm";
import { ErrorToast } from '../Errors/ErrorToast';
import { Link } from "react-router-dom";
import styles from '../Register/Register.module.css';

export const Register = () => {

    const { onRegisterSubmit, showError, onErrorClose, errorMessage } = useContext(AuthContext);

    const [formErrors, setFormErrors] = useState({
        username: '',
        firstName: '',
        lastName: '',
        email: '',
    });

    const { formValues, formChangeHandler, onSubmit } = useForm(
        {
            email: '',
            firstName: '',
            lastName: '',
            username: '',
            password: '',
            confirmPassword: '',
        }, onRegisterSubmit);

    const formValidate = (e) => {
        const value = e.target.value;
        const errors = {};

        if (e.target.name === 'email' && (value === '')) {
            errors.email = 'Email is required';
        }

        if (e.target.name === 'firstName' && (value.length < 1 || value.length > 30)) {
            errors.firstName = 'First name should be between 1 and 30 characters';
        }

        if (e.target.name === 'lastName' && (value.length < 1 || value.length > 30)) {
            errors.lastName = 'Last name should be between 1 and 30 characters';
        }

        if (e.target.name === 'username' && (value.length < 1 || value.length > 30)) {
            errors.username = 'Username should be between 1 and 30 characters';
        }

        setFormErrors(errors);
    };

    return (
        <div className={styles['wrapper']}>
            <ErrorToast
                show={showError}
                close={onErrorClose}
                errorMessage={errorMessage}
            />
            <Form className={styles['register-form']} onSubmit={onSubmit} method="POST">
                <h3 className={styles['header']}>Sign Up</h3>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>Username</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="username"
                        placeholder="Username"
                        value={formValues.username}
                        onChange={formChangeHandler}
                        onBlur={formValidate} />
                    {formErrors.username &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.username}
                        </p>
                    }
                </Form.Group>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>First Name</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="firstName"
                        placeholder="First Name"
                        value={formValues.firstName}
                        onChange={formChangeHandler}
                        onBlur={formValidate} />
                    {formErrors.firstName &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.firstName}
                        </p>
                    }
                </Form.Group>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>Last Name</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="lastName"
                        placeholder="Last Name"
                        value={formValues.lastName}
                        onChange={formChangeHandler}
                        onBlur={formValidate}
                    />
                    {formErrors.lastName &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.lastName}
                        </p>
                    }
                </Form.Group>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>Email address</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="email"
                        placeholder="Email"
                        value={formValues.email}
                        onChange={formChangeHandler}
                        onBlur={formValidate}
                    />
                    {formErrors.email &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.email}
                        </p>
                    }
                </Form.Group>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>Password</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="password"
                        placeholder="Password"
                        value={formValues.password}
                        onChange={formChangeHandler} />
                </Form.Group>
                <Form.Group className={`${styles['register-group']} mb-3`}>
                    <Form.Label className={styles['register-label']}>Confirm Password</Form.Label>
                    <Form.Control
                        type="text"
                        id="register"
                        name="confirmPassword"
                        placeholder="Confirm Password"
                        value={formValues.confirmPassword}
                        onChange={formChangeHandler} />
                </Form.Group>
                <Button className={styles['submit-btn']} variant="transparent" type="submit">
                    Register
                </Button>
                <div className={styles['form-footer']}>
                <Link to={"/login"} className={styles['footer-text']}>Already registered?</Link>
                </div>
            </Form>
        </div>
    );
};