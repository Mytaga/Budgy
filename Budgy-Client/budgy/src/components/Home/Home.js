import styles from "../Home/Home.module.css";
import { Link } from "react-router-dom";
import { Carousel } from "react-bootstrap";

export const Home = () => {
    return (
        <div className={styles['wrapper']}> 
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
            <section className={styles['second-section']}>
                <Carousel className={styles['carousel']} data-bs-theme="dark">
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://cdncloudcart.com/22293/files/image/bannermen.jpg"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <h5>First slide label</h5>
                            <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://cdncloudcart.com/22293/files/image/bannermen.jpg"
                            alt="Second slide"
                        />
                        <Carousel.Caption>
                            <h5>Second slide label</h5>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="d-block w-100"
                            src="https://cdncloudcart.com/22293/files/image/bannermen.jpg"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <h5>Third slide label</h5>
                            <p>
                                Praesent commodo cursus magna, vel scelerisque nisl consectetur.
                            </p>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </section>
        </div>
    );
};      