import styles from "../Home/Home.module.css";

export const Home = () => {
    return (
        <section className={styles['first-section']}>
            <div className={styles['main-header']}> 
                <h1>BUDGY BUDDY</h1>
                <h3>Control your budget and spendings in a inovative way !</h3>
            </div>
        </section>
    );
};  