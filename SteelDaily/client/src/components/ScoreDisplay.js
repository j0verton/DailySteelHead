import react from "react"
import { Col, Row } from "reactstrap";
import Star from "./Star";
// import 'bootstrap/dist/css/bootstrap.min.css';


const ScoreDisplay = ({ result, game }) => {

    return (
        <>
            {
                result.outcomes ?
                    <>
                        <Row m="5">
                            <Col sm={{ size: 10, order: 2, offset: 1 }}>
                                {result.outcomes.map(outcome => {
                                    console.log("outcome", outcome)
                                    return <Star outcome={outcome} />
                                })}
                            </Col>
                        </Row>
                    </>
                    : game ? null : <h3>Select A Key Then Begin</h3>
            }
        </>
    )
};
export default ScoreDisplay;