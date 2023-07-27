import { useState, useEffect, useContext } from "react";
import * as transactionService from '../../services/transactionService';
import { Accordion } from "react-bootstrap";
import { AuthContext } from "../../contexts/AuthContext";
import { Transaction } from "../Transaction/Transaction";

import styles from '../TransactionList/TransactionList.module.css';

export const TransactionList = () => {

    const [transactions, setTransactions] = useState([]);
    const { token } = useContext(AuthContext);

    useEffect(() => {
        transactionService.getAll(token)
            .then(transactions => {
                setTransactions(transactions)
            })
            .catch(error => console.log(error))
    }, [token],);

    return (
        <div className={styles['wrapper']}>
            <h3 className={styles['header']}>All Transactions</h3>
            <Accordion className={styles['accordion']}>
                {transactions.map((transaction) => (
                    <Transaction
                        key={transaction.id}
                        {...transaction}
                    />
                ))}
            </Accordion>
        </div>
    );
};