import react, { useEffect } from "react"
import { Card, CardBody, CardHeader, CardImg, Col, Media } from "reactstrap"
import ScoreDisplay from "./ScoreDisplay"
export const ActivityFeed = ({ activity }) => {

    return (
        <div>
            {console.log("activity", activity)}
            {
                activity ? activity.map(result => {
                    return (<Card key={result.result.id}>

                        <CardHeader>{result.result.userProfile.username}</CardHeader>
                        <Col>
                            <Media src={result.result.userProfile.imageLocation} alt="image of user" />
                        </Col>
                        <Col>
                            <CardBody>played {result.result.gameId} and scored {result.outcomes.filter(Boolean).length} / 10</CardBody>
                        </Col>
                    </Card>)
                }) : null
            }
        </div>




    )

}