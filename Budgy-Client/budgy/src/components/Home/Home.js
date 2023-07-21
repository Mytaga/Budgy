import styles from "../Home/Home.module.css";
import { Link } from "react-router-dom";

export const Home = () => {
    return (
        <section className={styles['first-section']}>
            <div className={styles['main-header']}>
                <h1>Welcome to Budgy. Your best spending buddy.</h1>
                <h3>Control your budget and spendings in a inovative way !</h3>
            </div>
            <div className={styles['set-up']}>
                <Link to={'/register'} className={`${styles['set-up-btn']} btn`}>
                    SET UP ACCOUNT
                </Link>
            </div>
        </section>
    );
};      