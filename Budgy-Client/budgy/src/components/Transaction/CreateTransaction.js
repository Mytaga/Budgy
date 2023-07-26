import { Form, Button } from "react-bootstrap";
import { useContext, useState, useEffect } from "react";
import { useForm } from "../../hooks/useForm";

import * as transactionService from '../../services/transactionService';

import styles from '../Transaction/CreateTransaction.module.css';
import { AuthContext } from "../../contexts/AuthContext";

export const CreateTransaction = () => {

    const { token, userId } = useContext(AuthContext);

    const [categories, setCategories] = useState([]);

    const [formErrors, setFormErrors] = useState({
        amount: '',
        type: '',
        description: '',
    });

    const onTransactionCreate = async (values) => {
        await transactionService(values, token);
    };

    const { formValues, formChangeHandler, onSubmit } = useForm(
        {
            amount: 0.00,
            type: '',
            userId: `${userId}`,
            categoryId: '',
            description: '',
        }, onTransactionCreate);

    const transactionType = formValues.type;

    useEffect(() => {
        transactionService.getCategories(transactionType, token)
            .then(transactionCategories => {
                setCategories(transactionCategories)
            })
            .catch(error => console.log(error))
    }, [transactionType, token]);

    const transactionFormValidate = (e) => {
        const value = e.target.value;
        const errors = {};

        if (e.target.name === 'amount' && (value <= 0)) {
            errors.content = 'Amoun must cannot be negative or 0';
        }

        if (e.target.name === 'amount' && (value === null)) {
            errors.content = 'Amount must be filled in';
        }

        if (e.target.name === 'description' && (value.length < 5 || value.length > 100)) {
            errors.content = 'Description should be between 5 and 100 characters';
        }

        setFormErrors(errors);
    }

    return (
        <div className={styles['wrapper']}>
            <Form className={styles['create-form']} onSubmit={onSubmit} method="POST">
                <Form.Group className="mb-3">
                    <Form.Label>Amount</Form.Label>
                    <Form.Control type="text"
                        id="amount"
                        name="amount"
                        placeholder="Amount"
                        value={formValues.amount}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate} />
                    {formErrors.username &&
                        <p className={`${styles['error']} form-error`}>
                            {formErrors.amount}
                        </p>
                    }
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Type</Form.Label>
                    <Form.Select
                        id="type"
                        name="type"
                        value={formValues.type}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate}>
                        <option>Transaction Type</option>
                        <option>Income</option>
                        <option>Expense</option>
                    </Form.Select>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Category</Form.Label>
                    <Form.Select
                        id="categoryId"
                        name="categoryId"
                        value={formValues.categoryId}
                        onChange={formChangeHandler}
                        onBlur={transactionFormValidate}
                    >
                        <option>Category Type</option>
                        {categories.map((c) => (<option key={c.id} value={c.id}>{c.name}</option>))}
                    </Form.Select>
                </Form.Group>
                <Button variant="transparent" type="submit">
                    Make
                </Button>
            </Form>
        </div>
    );
};