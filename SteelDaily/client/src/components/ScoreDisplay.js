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
                            <Col sm={{ size: 12, order: 2, offset: 1 }} className="d-flex flex-nowrap">
                                {result.outcomes.map(outcome => {
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