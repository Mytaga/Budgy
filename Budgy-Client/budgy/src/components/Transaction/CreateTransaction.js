import { Form, Button } from "react-bootstrap";
import { useContext, useState } from "react";
import { useForm } from "../../hooks/useForm";

import * as transactionService from '../../services/transactionService';

import styles from '../Transaction/CreateTransaction.module.css';
import { AuthContext } from "../../contexts/AuthContext";

export const CreateTransaction = () => {

    const { token, userId } = useContext(AuthContext);

    const [formErrors, setFormErrors] = useState({
        amount: '',
        userId: `${userId}`,
        categoryId: '',
        description: '',
    });

    const { formValues, formChangeHandler, onSubmit } = useForm(
        {
            amount: 0,
            description: '',
        }, onTransactionCreate);

    const onTransactionCreate = async (values) => {
        const created = await transactionService(values, token);
    };

    return (
        <div className={styles['wrapper']}>
            <Form className={styles['create-form']} method="POST">
                <Form.Group className="mb-3">
                    <Form.Label>Amount</Form.Label>
                    <Form.Control type="text" />
                    <Form.Text className="text-muted">
                    </Form.Text>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Type</Form.Label>
                    <Form.Select>
                        <option>Transaction Type</option>
                        <option>Income</option>
                        <option>Expense</option>
                    </Form.Select>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Category</Form.Label>
                    <Form.Select>
                        <option>Category Type</option>
                    </Form.Select>
                </Form.Group>
                <Button variant="transparent" type="submit">
                    Make
                </Button>
            </Form>
        </div>
    );
};