import { Accordion } from "react-bootstrap";

import styles from '../Transaction/Transaction.module.css';

export const Transaction = ({
    id,
    amount,
    type,
    time,
    categoryName,
    description,
}) => {
    return (
        <Accordion.Item className={styles['accordion-item']}>
            <Accordion.Header className={styles['accordion-header']}>{time} - {amount}lv </Accordion.Header>
            <Accordion.Body className={styles['accordion-body']}>
                <span>Amount : {amount}lv</span>
                <span>Type : {type}</span>
                <span>Time : {time}</span>
                <span>Category : {categoryName}</span>
                <span>Description : {description}</span>
            </Accordion.Body>
        </Accordion.Item>
    );
}   