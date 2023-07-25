import { Accordion } from "react-bootstrap";

export const Transaction = ({
    id,
    amount,
    time,
}) => {
    return (
        <Accordion.Item eventKey="0">
            <Accordion.Header>{time}</Accordion.Header>
            <Accordion.Body>
                {amount}
            </Accordion.Body>
        </Accordion.Item>
    );
}