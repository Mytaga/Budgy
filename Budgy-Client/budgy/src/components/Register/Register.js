import { Form, Button } from "react-bootstrap";
import styles from '../Register/Register.module.css';

export const Register = () => {
    return (
        <Form className={styles['register-form']}>
            <Form.Group className="mb-3" controlId="formGroupUsername">
                <Form.Label className={styles['register-label']}>Username</Form.Label>
                <Form.Control type="text" placeholder="Username" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupFirstname">
                <Form.Label className={styles['register-label']}>First Name</Form.Label>
                <Form.Control type="text" placeholder="First Name" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupLastname">
                <Form.Label className={styles['register-label']}>Last Name</Form.Label>
                <Form.Control type="text" placeholder="Last Name" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label className={styles['register-label']}>Email address</Form.Label>
                <Form.Control type="email" placeholder="Email" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupPassword">
                <Form.Label className={styles['register-label']}>Password</Form.Label>
                <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupConfirmPassword">
                <Form.Label className={styles['register-label']}>Confirm Password</Form.Label>
                <Form.Control type="password" placeholder="Confirm Password" />
            </Form.Group>
            <Button className={styles['submit-btn']} variant="transparent" type="submit">
                Submit
            </Button>
        </Form>
    );
};