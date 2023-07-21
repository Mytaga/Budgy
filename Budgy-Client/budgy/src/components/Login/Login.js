import { Form, Button } from "react-bootstrap";
import styles from '../Login/Login.module.css';

export const Login = () => {
    return (
        <Form className={styles['login-form']}> 
            <Form.Group className="mb-3" controlId="formGroupEmail">
                <Form.Label className={styles['login-label']}>Email address</Form.Label>
                <Form.Control type="email" placeholder="Enter email" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formGroupPassword">
                <Form.Label className={styles['login-label']}>Password</Form.Label>
                <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Button className={styles['submit-btn']}variant="transparent" type="submit">
                Submit
            </Button>
        </Form>
    );
};