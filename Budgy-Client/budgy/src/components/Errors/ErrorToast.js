import { Toast } from "react-bootstrap";
import styles from '../Errors/ErrorToast.module.css';

export const ErrorToast = ({
    show,
    close,
    errorMessage,
}) => {
    return (
        <Toast show={show} onClose={close} >
          <Toast.Header className={`${styles['header']} bg`}>
            <img src="holder.js/20x20?text=%20" className="rounded me-2" alt="" />
            <strong className="me-auto">Error</strong>
          </Toast.Header>
          <Toast.Body>{errorMessage}</Toast.Body>
        </Toast>
      );
};