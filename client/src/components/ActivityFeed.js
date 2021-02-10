import react, { useEffect } from "react"
import { Card, CardBody, CardHeader, CardImg, Col, Media, Row } from "reactstrap"
import ScoreDisplay from "./ScoreDisplay"
export const ActivityFeed = ({ activity }) => {

    return (
        <div>
            {
                activity ? activity.map(result => {
                    return (<Card key={result.result.id} className="mt-1">

                        <CardHeader><h2 className="text-left">{result.result.userProfile.username}</h2></CardHeader>
                        <Row>
                            <Col xs="4">
                                <Media src={result.result.userProfile.imageLocation} alt="image of user" />
                            </Col>
                            <Col xs="6">
                                played <h3>{result.result.game.name}</h3>
                                and scored <h3>{result.outcomes.filter(Boolean).length} / 10</h3>


                            </Col>
                        </Row>
                    </Card>)
                }) : null
            }
        </div >




    )

}